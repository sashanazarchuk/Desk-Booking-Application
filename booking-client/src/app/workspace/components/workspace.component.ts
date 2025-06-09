import { Component, Input } from '@angular/core';
import { WorkspaceService } from '../../core/services/workspace.service';
import { AsyncPipe, DatePipe, NgFor, NgIf } from '@angular/common';
import { environment } from '../../environment';
import { map, Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Workspace, WorkspaceType } from '../../core/models/workspace.model';
import { Booking } from '../../core/models/booking.model';
import { BookingService } from '../../core/services/booking.service';
import { CoworkingService } from '../../core/services/coworking.service';

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
  image = environment.imageURL;
  public WorkspaceType = WorkspaceType;


  constructor(private coworkingService: CoworkingService, private bookingServe: BookingService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.bookings$ = this.bookingServe.getAllBookings();

    this.route.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      if (id) {
        this.coworkingId = id;
        this.workspaces$ = this.coworkingService.getWorkspaceByCoworkingId(id);
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
