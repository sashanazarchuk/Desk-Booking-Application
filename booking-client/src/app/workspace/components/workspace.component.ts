import { Component, } from '@angular/core';
import { AsyncPipe, DatePipe, NgFor, NgIf } from '@angular/common';
import { environment } from '../../environment';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Workspace, WorkspaceType } from '../../core/models/workspace.model';
import { Booking } from '../../core/models/booking.model';
import { BookingService } from '../../core/services/booking.service';
import { AppState } from '../../store/types/appState';
import { Store } from '@ngrx/store';
import * as WorkspaceActions from '../../store/workspace/workspace.actions';
import { selectIsLoadingWorkspace, selectWorkspaceError, selectWorkspacesByCoworkingId } from '../../store/workspace/workspace.selectors';
@Component({
  selector: 'app-workspace',
  imports: [NgFor, NgIf, AsyncPipe, DatePipe],
  templateUrl: './workspace.component.html',
  styleUrl: './workspace.component.css'
})


export class WorkspaceComponent {

  workspaces$!: Observable<Workspace[]>;
  coworkingId!: number;
  bookings$!: Observable<Booking[]>;
  isLoading$!: Observable<boolean>;
  error$!: Observable<string | null>;
  image = environment.imageURL;
  public WorkspaceType = WorkspaceType;


  constructor(private store: Store<AppState>, private bookingServe: BookingService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.bookings$ = this.bookingServe.getAllBookings();

    this.route.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      if (id) {
        this.coworkingId = id;
        this.store.dispatch(WorkspaceActions.loadWorkspaceByCoworkingId({ workspaceId: id }));
        this.workspaces$ = this.store.select(selectWorkspacesByCoworkingId(id));
        this.isLoading$ = this.store.select(selectIsLoadingWorkspace);
        this.error$ = this.store.select(selectWorkspaceError);
      }
    });
  }


  hasNonOpenSpaceRooms(workspace: Workspace): boolean {
    return workspace.rooms.some(room => room.workspaceType != WorkspaceType.OpenSpace);
  }

  formatRoomsCountText(count: number): string {
    return count === 1 ? 'room' : 'rooms';
  }

  formatCapacityText(capacity: number): string {
    return capacity > 1 ? `for up to ${capacity} people` : `for ${capacity} person`;
  }

  createBooking(id: number) {
    this.router.navigate(['create', id]);
  }

}
