import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../config/api';
import { PersonaCorreoDto } from '../../models/persona-correo/PersonaCorreoDto.model';

@Injectable({
  providedIn: 'root',
})
export class PersonaCorreoService {
  private http = inject(HttpClient);
  private apiUrl = `${API_BASE_URL}/personacorreo`;

  getAll(personaId?: number): Observable<PersonaCorreoDto[]> {
    const url = personaId ? `${this.apiUrl}?personaId=${personaId}` : this.apiUrl;
    return this.http.get<PersonaCorreoDto[]>(url);
  }

  getById(id: number): Observable<PersonaCorreoDto> {
    return this.http.get<PersonaCorreoDto>(`${this.apiUrl}/${id}`);
  }

  create(data: PersonaCorreoDto): Observable<PersonaCorreoDto> {
    return this.http.post<PersonaCorreoDto>(this.apiUrl, data);
  }

  update(data: PersonaCorreoDto): Observable<PersonaCorreoDto> {
    return this.http.put<PersonaCorreoDto>(this.apiUrl, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

