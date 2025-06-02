import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, throwError } from "rxjs";
import { Booking, BookingCreatePayload } from "../models/booking.model";

@Injectable({
    providedIn: 'root'
})


export class BookingService {

    private URL = 'https://localhost:7198/api/Booking';


    constructor(private http: HttpClient) { }

    createBooking(payload: BookingCreatePayload): Observable<any> {
        return this.http.post<Booking>(this.URL, payload);
    }


    patchBooking(bookingId: number, patchDoc: any[]) {
        return this.http.patch(`${this.URL}/${bookingId}`, patchDoc);
    }


    getAllBookings(): Observable<Booking[]> {
        return this.http.get<Booking[]>(this.URL).pipe(
            catchError((error) => {
                console.error('Error fetching bookings:', error);
                return throwError(() => new Error('Failed to fetch bookings.'));
            })
        );
    }


    deleteBooking(id: number) {
        return this.http.delete(`${this.URL}/${id}`);
    }












}