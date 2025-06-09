import { Routes } from '@angular/router';
import { WorkspaceComponent } from './workspace/components/workspace.component';
import { BookingsHistoryComponent } from './bookings-history/components/bookings-history.component';
import { BookingFormComponent } from './booking-form/booking-form.component';
import { CoworkingComponent } from './coworking/coworking.component';
import { AiAssistantComponent } from './ai-assistant/ai-assistant.component';


export const routes: Routes = [

    { path: '', redirectTo: 'coworking', pathMatch: 'full' },
    { path: 'coworking', component: CoworkingComponent },
    { path: 'workspace/:id', component: WorkspaceComponent },
    { path: 'history', component: BookingsHistoryComponent },
    { path: 'create/:coworkingId', component: BookingFormComponent },
    { path: 'edit/:id', component: BookingFormComponent },
    { path: 'chat', component: AiAssistantComponent },
    
];
