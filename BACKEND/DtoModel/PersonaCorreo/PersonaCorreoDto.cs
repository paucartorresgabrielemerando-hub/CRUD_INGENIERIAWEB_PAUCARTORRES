using System;

namespace DtoModel.PersonaCorreo
{
    public class PersonaCorreoDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Correo { get; set; } = null!;
        public bool EsPrincipal { get; set; }
        public int UserCreate { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}

