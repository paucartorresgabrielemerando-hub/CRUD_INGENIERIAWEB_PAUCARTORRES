using System;

namespace DtoModel.PersonaEmpleo
{
    public class PersonaEmpleoDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Empresa { get; set; } = null!;
        public string? Cargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? Salario { get; set; }
        public int UserCreate { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}

