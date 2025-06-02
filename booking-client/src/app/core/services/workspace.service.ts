import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Workspace } from '../models/workspace.model';
import { Booking } from '../models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class WorkspaceService {

  private URL = "https://localhost:7198/api/"

  constructor(private http: HttpClient) { }

  getAllWorkspaces(): Observable<Workspace[]> {
    return this.http.get<Workspace[]>(`${this.URL}Workspace`).pipe(
      catchError((error) => {
        console.error('Error fetching workspaces:', error);
        return throwError(() => new Error('Failed to fetch workspaces.'));
      })
    );
  }

  getBookingById(id: number): Observable<Booking> {
    return this.http.get<Booking>(`${this.URL}Booking/${id}`);
  }

  updateBooking(id: number, payload: any): Observable<any> {
    return this.http.patch(`${this.URL}Booking/${id}`, payload);
  }
  
}
