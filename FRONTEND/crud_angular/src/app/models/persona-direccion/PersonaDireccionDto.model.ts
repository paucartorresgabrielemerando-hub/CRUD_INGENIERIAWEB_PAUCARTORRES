export class PersonaDireccionDto {
  id: number = 0;
  idPersona: number = 0;
  tipo: string = 'CASA';
  direccion: string = '';
  ciudad: string | null = '';
  region: string | null = '';
  codigoPostal: string | null = '';
  userCreate: number = 0;
  userUpdate: number | null = 0;
  dateCreated: string | null = '';
  dateUpdate: string | null = '';
}

