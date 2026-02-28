import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../config/api';
import { PersonaDireccionDto } from '../../models/persona-direccion/PersonaDireccionDto.model';

@Injectable({
  providedIn: 'root',
})
export class PersonaDireccionService {
  private http = inject(HttpClient);
  private apiUrl = `${API_BASE_URL}/personadireccion`;

  getAll(personaId?: number): Observable<PersonaDireccionDto[]> {
    const url = personaId ? `${this.apiUrl}?personaId=${personaId}` : this.apiUrl;
    return this.http.get<PersonaDireccionDto[]>(url);
  }

  getById(id: number): Observable<PersonaDireccionDto> {
    return this.http.get<PersonaDireccionDto>(`${this.apiUrl}/${id}`);
  }

  create(data: PersonaDireccionDto): Observable<PersonaDireccionDto> {
    return this.http.post<PersonaDireccionDto>(this.apiUrl, data);
  }

  update(data: PersonaDireccionDto): Observable<PersonaDireccionDto> {
    return this.http.put<PersonaDireccionDto>(this.apiUrl, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

