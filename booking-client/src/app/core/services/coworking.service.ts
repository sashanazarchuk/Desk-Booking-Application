import { HttpClient } from "@angular/common/http";
import { catchError, Observable, throwError } from "rxjs";
import { Coworking } from "../models/coworking.model";
import { Injectable } from "@angular/core";
import { Workspace } from "../models/workspace.model";



@Injectable({
    providedIn: 'root'
})

export class CoworkingService{

private URL = "https://localhost:7198/api/"

  constructor(private http: HttpClient) { }

  getAllCoworkings(): Observable<Coworking[]> {
    return this.http.get<Coworking[]>(`${this.URL}Coworking`).pipe(
      catchError((error) => {
        console.error('Error fetching coworkings:', error);
        return throwError(() => new Error('Failed to fetch coworking.'));
      })
    );
  }


    getWorkspaceByCoworkingId(id: number): Observable<Workspace[]> {
      return this.http.get<Workspace[]>(`${this.URL}Coworking/${id}`);
    }

}