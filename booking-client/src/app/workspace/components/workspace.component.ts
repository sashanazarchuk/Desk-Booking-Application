import { Component } from '@angular/core';
import { WorkspaceService } from '../../core/services/workspace.service';
import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { environment } from '../../environment';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Workspace, WorkspaceType } from '../../core/models/workspace.model';

@Component({
  selector: 'app-workspace',
  imports: [NgFor, NgIf, AsyncPipe,],
  templateUrl: './workspace.component.html',
  styleUrl: './workspace.component.css'
})


export class WorkspaceComponent {


  workspaces$!: Observable<Workspace[]>;
  image = environment.imageURL;
  public WorkspaceType = WorkspaceType;


  constructor(private workspaceService: WorkspaceService, private router: Router) { }

  ngOnInit() {
    this.workspaces$ = this.workspaceService.getAllWorkspaces();
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


  createBooking( ) {
    this.router.navigate(['create' ]);
  }

}
