import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../config/api';
import { PersonaTipoDocumentoDto } from '../../models/persona-tipo-documento/PersonaTipoDocumentoDto.model';

@Injectable({
  providedIn: 'root',
})
export class PersonaTipoDocumentoService {
  private readonly http = inject(HttpClient);

  // Ahora usamos el endpoint existente en PersonaController: GET /api/Persona/tipos-documento
  private readonly apiUrl = `${API_BASE_URL}/Persona/tipos-documento`;

  getAll(): Observable<PersonaTipoDocumentoDto[]> {
    return this.http.get<PersonaTipoDocumentoDto[]>(this.apiUrl);
  }
}

