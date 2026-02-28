import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../config/api';
import { PersonaEmpleoDto } from '../../models/persona-empleo/PersonaEmpleoDto.model';

@Injectable({
  providedIn: 'root',
})
export class PersonaEmpleoService {
  private http = inject(HttpClient);
  private apiUrl = `${API_BASE_URL}/personaempleo`;

  getAll(personaId?: number): Observable<PersonaEmpleoDto[]> {
    const url = personaId ? `${this.apiUrl}?personaId=${personaId}` : this.apiUrl;
    return this.http.get<PersonaEmpleoDto[]>(url);
  }

  getById(id: number): Observable<PersonaEmpleoDto> {
    return this.http.get<PersonaEmpleoDto>(`${this.apiUrl}/${id}`);
  }

  create(data: PersonaEmpleoDto): Observable<PersonaEmpleoDto> {
    return this.http.post<PersonaEmpleoDto>(this.apiUrl, data);
  }

  update(data: PersonaEmpleoDto): Observable<PersonaEmpleoDto> {
    return this.http.put<PersonaEmpleoDto>(this.apiUrl, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

