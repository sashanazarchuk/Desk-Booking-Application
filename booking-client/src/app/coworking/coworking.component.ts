import { Component, OnInit } from '@angular/core';
import { environment } from '../environment';
import { Observable } from 'rxjs';
import { Coworking } from '../core/models/coworking.model';
import { CoworkingService } from '../core/services/coworking.service';
import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Workspace } from '../core/models/workspace.model';
import { Router } from '@angular/router';
import { EmptyBookingsComponent } from "../empty-bookings/empty-bookings.component";
import { select, Store } from '@ngrx/store';
import * as CoworkingActions from '../store/coworking/coworking.actions'
import { coworkingSelector, errorSelector, isLoadingSelector } from '../store/coworking/coworking.selectors';
import { AppState } from '../store/types/AppState';


@Component({
  selector: 'app-coworking',
  imports: [NgFor, AsyncPipe, NgIf, EmptyBookingsComponent],
  templateUrl: './coworking.component.html',
  styleUrl: './coworking.component.css'
})
export class CoworkingComponent implements OnInit {

  image = environment.imageURL;

  coworking$: Observable<Coworking[]>;
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;
  selectedCoworkingId!: number;


  constructor(private router: Router, private store: Store<AppState>) {
    this.isLoading$ = this.store.pipe(select(isLoadingSelector));
    this.coworking$ = this.store.pipe(select(coworkingSelector));
    this.error$ = this.store.pipe(select(errorSelector));

  }

  ngOnInit() {
    this.store.dispatch(CoworkingActions.loadAllCoworkings());
  }

  goToWorkspaces(id: number) {
    this.router.navigate(['/workspace', id]);
  }


}