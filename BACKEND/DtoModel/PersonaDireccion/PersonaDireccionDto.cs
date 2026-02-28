using System;

namespace DtoModel.PersonaDireccion
{
    public class PersonaDireccionDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Tipo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Ciudad { get; set; }
        public string? Region { get; set; }
        public string? CodigoPostal { get; set; }
        public int UserCreate { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}

