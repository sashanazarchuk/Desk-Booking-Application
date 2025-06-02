import { Routes } from '@angular/router';
import { WorkspaceComponent } from './workspace/components/workspace.component';
import { BookingsHistoryComponent } from './bookings-history/components/bookings-history.component';
import { BookingFormComponent } from './booking-form/booking-form.component';


export const routes: Routes = [

    { path: '', redirectTo: 'workspace', pathMatch: 'full' },
    { path: 'workspace', component: WorkspaceComponent },
    { path: 'history', component: BookingsHistoryComponent },
    { path: 'create', component: BookingFormComponent },
    { path: 'edit/:id', component: BookingFormComponent },
];
