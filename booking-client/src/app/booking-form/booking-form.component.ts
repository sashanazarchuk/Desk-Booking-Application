import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Component, inject, ViewChild } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ModalComponent } from '../modal/modal.component';
import { WorkspaceService } from '../core/services/workspace.service';
import { getWorkspaceChangeState } from '../core/utils/workspace.utils';
import { combineDateTime, updateCalendar } from '../core/utils/date.utils';
import { BookingService } from '../core/services/booking.service';
import { createPatchDoc } from '../core/utils/booking.utils';
import { ErrorHandlerService } from '../core/services/error-handler.service';
import { DateTimePickerComponent } from "../date-time-picker/date-time-picker.component";
import { Workspace, WorkspaceType } from '../core/models/workspace.model';
import { BookingCreatePayload } from '../core/models/booking.model';
import { Room } from '../core/models/room.model';
import { CoworkingService } from '../core/services/coworking.service';

@Component({
  selector: 'app-booking-form',
  imports: [NgFor, NgIf, AsyncPipe, FormsModule, DateTimePickerComponent],
  templateUrl: './booking-form.component.html',
  styleUrl: './booking-form.component.css'
})
export class BookingFormComponent {

  @ViewChild(DateTimePickerComponent) calendar!: DateTimePickerComponent;

  readonly dialog = inject(MatDialog);
  private subscription!: Subscription;

  workspaces$!: Observable<Workspace[]>;

  workspaces: Workspace[] = [];
  selectedWorkspaceId: string = '';
  showDropdown = false;
  showRadioButtons = false;
  selectedRoomId!: number;
  selectedRoomType: WorkspaceType | null = null;
  bookingId?: number;
  isEditMode = false;
  coworkingId!: number;


  name = '';
  email = '';
  selectedSeats = 1;
  errorMessage = '';
  formErrors: { [key: string]: string[] } = {};
  generalErrors: string[] = [];

  constructor(private workspaceService: WorkspaceService, private coworkingService: CoworkingService, private errorHandlerService: ErrorHandlerService, private route: ActivatedRoute, private bookingService: BookingService) { }


  // Component initialization: get route parameters, load workspaces, define editing mode

  ngOnInit(): void {
    this.route.url.subscribe(segments => {
      this.isEditMode = segments.some(s => s.path === 'edit');

      if (this.isEditMode) {
        const bookingId = Number(this.route.snapshot.paramMap.get('id'));
        if (bookingId) {
          this.bookingId = bookingId;
          this.loadBooking(bookingId); // load booking and workspaces
        }
      } else {
        const coworkingId = Number(this.route.snapshot.paramMap.get('coworkingId'));
        if (coworkingId) {
          this.coworkingId = coworkingId;
          this.loadWorkspaces(coworkingId); // only load workspaces
        }
      }
    });
  }


  // Loads booking data by ID, fills the form, and updates the workspace selection state
  loadBooking(id: number) {
    this.workspaceService.getBookingById(id,).subscribe(booking => {
      this.name = booking.name;
      this.email = booking.email;
      this.selectedRoomId = booking.roomId;
      this.selectedSeats = booking.seatsBooked;
      this.selectedWorkspaceId = booking.workspace.name;
      this.coworkingId = booking.workspace.coworkingId;

      updateCalendar(this.calendar, new Date(booking.startDate), new Date(booking.endDate));
      this.loadWorkspaces(this.coworkingId, true);
    });
  }

  // Handles change of selected workspace, updates UI depending on room type
  onWorkspaceChange(): void {
    const result = getWorkspaceChangeState(this.workspaces, this.selectedWorkspaceId);
    this.showDropdown = result.showDropdown;
    this.showRadioButtons = result.showRadioButtons;
    this.selectedRoomType = result.selectedRoomType;
    this.selectedRoomId = result.selectedRoomId;
  }


  loadWorkspaces(coworkingId: number, callOnWorkspaceChange = false): void {
    this.workspaces$ = this.coworkingService.getWorkspaceByCoworkingId(coworkingId);
    this.subscription = this.workspaces$.subscribe(ws => {
      this.workspaces = ws;
      if (callOnWorkspaceChange && this.selectedWorkspaceId) {
        this.onWorkspaceChange();
      }
    });
  }


  // Creates a new reservation after validating dates and times, shows a success or error message
  submitReservation() {
    const validationError = this.calendar.validateDateTimes();

    if (validationError) {
      this.dialog.open(ModalComponent, {
        width: '400px',
        data: {
          imageUrl: 'icons/error.svg',
          title: 'Error in date or time selection',
          message: validationError,
          showConfirm: false,
          cancelText: 'Check availability'
        }
      });
      return;
    }

    const { startDate, endDate, startTime, endTime } = this.calendar;

    if (!startDate || !endDate || !startTime || !endTime) {
      return;
    }



    const start = combineDateTime(startDate, startTime);
    const end = combineDateTime(endDate, endTime);

    const room = this.workspaces
      .flatMap(ws => ws.rooms)
      .find(r => r.id === this.selectedRoomId);



    let seatsText = '';
    if (room) {
      seatsText = room.workspaceType === WorkspaceType.OpenSpace
        ? `${this.selectedSeats} ${this.selectedSeats === 1 ? 'person' : 'people'}`
        : `${room.capacity} ${room.capacity === 1 ? 'person' : 'people'}`;
    }


    const payload: BookingCreatePayload = {
      name: this.name,
      email: this.email,
      roomId: this.selectedRoomId,
      seatsToBook: this.selectedSeats,
      startDate: start,
      endDate: end
    };

    this.bookingService.createBooking(payload).subscribe({
      next: () => {
        this.dialog.open(ModalComponent, {
          width: '70%',
          data: {
            title: "You're all set!",
            imageUrl: "icons/success.svg",
            message: `Your room for <span class="font-medium">${seatsText}</span> is booked from <span class="font-medium">${new Date(start).toDateString()}</span> to <span class="font-medium">${new Date(end).toDateString()}</span>. A confirmation has been sent to your email <span class="font-medium">${this.email}</span>.`,
            showConfirm: false,
            cancelText: 'My bookings',
            redirectToWorkspace: true
          }
        });
      },
      error: err => {
        this.errorHandlerService.handleApiError(err);
        this.formErrors = this.errorHandlerService.formErrors;
        this.generalErrors = this.errorHandlerService.generalErrors;
        this.errorMessage = this.errorHandlerService.errorMessage;
      }
    });

  }


  // Updates an existing reservation (PATCH) after validating dates and times, shows a success or error message
  patchReservation() {
    const validationError = this.calendar.validateDateTimes();

    if (validationError) {
      this.dialog.open(ModalComponent, {
        width: '400px',
        data: {
          imageUrl: 'icons/error.svg',
          title: 'Error in date or time selection',
          message: validationError,
          showConfirm: false,
          cancelText: 'Check availability'
        }
      });
      return;
    }

    const { startDate, endDate, startTime, endTime } = this.calendar;

    if (!startDate || !endDate || !startTime || !endTime) {
      return;
    }

    const start = combineDateTime(startDate, startTime);
    const end = combineDateTime(endDate, endTime);

    const patchDoc = createPatchDoc(this.name, this.email, this.selectedRoomId, this.selectedSeats, start, end);
    if (!this.bookingId) {
      return;
    }

    this.bookingService.patchBooking(this.bookingId, patchDoc).subscribe({
      next: () => {
        this.dialog.open(ModalComponent, {
          width: '70%',
          data: {
            title: "You're all set!",
            imageUrl: "icons/success.svg",
            message: `Your room booking has been successfully updated`,
            showConfirm: false,
            cancelText: 'My bookings',
            redirectToWorkspace: true
          }
        });
      },
      error: err => {
        this.errorHandlerService.handleApiError(err);
        this.formErrors = this.errorHandlerService.formErrors;
        this.generalErrors = this.errorHandlerService.generalErrors;
        this.errorMessage = this.errorHandlerService.errorMessage;
      }
    });
  }

  // Unsubscribes when the component is destroyed to avoid memory leaks
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }


}
