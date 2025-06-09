import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-empty-bookings',
  imports: [RouterModule],
  templateUrl: './empty-bookings.component.html',
  styleUrl: './empty-bookings.component.css'
})
export class EmptyBookingsComponent {
  @Input() title: string = 'You don’t have any bookings yet';
  @Input() subtitle: string = 'Start by choosing a coworking space';
  @Input() buttonText: string = 'Select a coworking';
  @Input() routerLink: string = '/coworking';
}
