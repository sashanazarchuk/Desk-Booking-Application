import { Component, inject } from '@angular/core';
import { EmptyBookingsComponent } from "../../empty-bookings/empty-bookings.component";
import { AsyncPipe, DatePipe, NgFor, NgIf } from '@angular/common';
import { environment } from '../../environment';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { ModalComponent } from '../../modal/modal.component';
import { MatDialog } from '@angular/material/dialog';
import { Booking } from '../../core/models/booking.model';
import { WorkspaceType } from '../../core/models/workspace.model';
import { BookingService } from '../../core/services/booking.service';

@Component({
  selector: 'app-bookings-history',
  imports: [EmptyBookingsComponent, NgIf, NgFor, DatePipe, AsyncPipe],
  templateUrl: './bookings-history.component.html',
  styleUrl: './bookings-history.component.css'
})
export class BookingsHistoryComponent {

  bookings$!: Observable<Booking[]>;

  image = environment.imageURL;

  readonly dialog = inject(MatDialog);
  constructor(private bookingService: BookingService, private router: Router) { }

  WorkspaceType = WorkspaceType;

  ngOnInit(): void {
    this.bookings$ = this.bookingService.getAllBookings();
  }

  editBooking(id: number) {
    this.router.navigate(['/edit', id]);
  }

 
  getDurationDays(booking: Booking): string {
    const start = new Date(booking.startDate);
    const end = new Date(booking.endDate);
    const room = booking.workspace.rooms.find(r => r.id === booking.roomId);
    if (!room) return '';

    if (room.workspaceType !== WorkspaceType.MeetingRoom) {
      const diffMs = end.getTime() - start.getTime();
      const diffDays = Math.ceil(diffMs / (1000 * 60 * 60 * 24));
      return `(${diffDays} day${diffDays > 1 ? 's' : ''})`;
    }
    return '';
  }


  //Calculates the duration of  a reservation in a convenient text format, but only for rooms of type `MeetingRoom`
  getDurationHours(booking: Booking): string {
    const start = new Date(booking.startDate);
    const end = new Date(booking.endDate);
    const room = booking.workspace.rooms.find(r => r.id === booking.roomId);
    if (!room) return '';

    if (room.workspaceType === WorkspaceType.MeetingRoom) {
      const diffMs = end.getTime() - start.getTime();
      const totalMinutes = Math.round(diffMs / (1000 * 60));
      const hours = Math.floor(totalMinutes / 60);
      const minutes = totalMinutes % 60;

      if (hours === 0) {
        return `(${totalMinutes} minute${totalMinutes !== 1 ? 's' : ''})`;
      } else if (minutes === 0) {
        return `(${hours} hour${hours > 1 ? 's' : ''})`;
      } else {
        const paddedMinutes = minutes.toString().padStart(2, '0');
        return `(${hours}:${paddedMinutes} hours)`;
      }
    }
    return '';
  }


  openDialog(type: 'success' | 'confirm', id?: number, imageUrl?: string) {
    const data: any = {};

    if (type === 'success') {
      data.showConfirm = false;
    } else if (type === 'confirm') {
      data.title = 'Are you sure you want to cancel this booking?';
      data.message = 'This action cannot be undone';
      data.showConfirm = true;
      data.confirmText = 'Yes, cancel it';
      data.cancelText = 'No, keep it';
    }
    if (imageUrl) {
      data.imageUrl = imageUrl;
    }
    const dialogRef = this.dialog.open(ModalComponent, {
      width: '70%',
      data
    });

    dialogRef.afterClosed().subscribe(result => {
      if (type === 'confirm' && result) {
        this.deleteBooking(id);
      }
    });
  }


  deleteBooking(id?: number) {
    if (!id) return;

    this.bookingService.deleteBooking(id).subscribe(() => {
      this.bookings$ = this.bookingService.getAllBookings();
    });
  }

}
