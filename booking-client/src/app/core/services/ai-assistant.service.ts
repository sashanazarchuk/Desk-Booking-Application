import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class AiAssistantService {
    private URL = 'https://localhost:7198/api/';

    constructor(private http: HttpClient) { }


    chatWithAI(message: string): Observable<{ reply: string }> {
        return this.http.post<{ reply: string }>(`${this.URL}AI/chat`, { message });
    }


}