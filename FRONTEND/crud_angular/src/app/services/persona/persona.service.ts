import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { PersonaDto } from '../../models/persona/PersonaDto.model';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../config/api';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {



//inyectar el servicio de httpclient
http = inject(HttpClient);

private apiUrl = `${API_BASE_URL}/persona`;

constructor() { }

  getAll(): Observable<PersonaDto[]> {
    return this.http.get<PersonaDto[]>(this.apiUrl);
  }


  create(data: PersonaDto):Observable<PersonaDto> {
    return this.http.post<PersonaDto>(this.apiUrl, data);
  }

  update(id: number, data: PersonaDto): Observable<PersonaDto> {
    const url = `${this.apiUrl}`;
    return this.http.put<PersonaDto>(url, data);
  }

  delete(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }

}
