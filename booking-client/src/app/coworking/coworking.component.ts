import { Component } from '@angular/core';
import { environment } from '../environment';
import { Observable } from 'rxjs';
import { Coworking } from '../core/models/coworking.model';
import { CoworkingService } from '../core/services/coworking.service';
import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Workspace } from '../core/models/workspace.model';
import { Router } from '@angular/router';
import { EmptyBookingsComponent } from "../empty-bookings/empty-bookings.component";

@Component({
  selector: 'app-coworking',
  imports: [NgFor, AsyncPipe, NgIf, EmptyBookingsComponent],
  templateUrl: './coworking.component.html',
  styleUrl: './coworking.component.css'
})
export class CoworkingComponent {

  image = environment.imageURL;

  coworking$!: Observable<Coworking[]>;
  workspaces$!: Observable<Workspace[]>;
  selectedCoworkingId!: number;


  constructor(private coworkingService: CoworkingService, private router: Router) { }


  ngOnInit() {
    this.coworking$ = this.coworkingService.getAllCoworkings();
  }

  goToWorkspaces(id: number) {
    this.router.navigate(['/workspace', id]);
  }


}
