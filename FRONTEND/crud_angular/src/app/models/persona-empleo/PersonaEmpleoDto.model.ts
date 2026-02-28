export class PersonaEmpleoDto {
  id: number = 0;
  idPersona: number = 0;
  empresa: string = '';
  cargo: string | null = '';
  fechaInicio: string = ''; // YYYY-MM-DD
  fechaFin: string | null = ''; // YYYY-MM-DD
  salario: number | null = null;
  userCreate: number = 0;
  userUpdate: number | null = 0;
  dateCreated: string | null = '';
  dateUpdate: string | null = '';
}

