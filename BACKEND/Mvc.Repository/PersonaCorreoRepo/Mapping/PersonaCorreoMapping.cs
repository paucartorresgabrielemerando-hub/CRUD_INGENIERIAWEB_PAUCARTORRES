using DbModel.demoDb;
using DtoModel.PersonaCorreo;

namespace Mvc.Repository.PersonaCorreoRepo.Mapping
{
    public static class PersonaCorreoMapping
    {
        public static PersonaCorreoDto ToDto(this PersonaCorreo correo)
        {
            return new PersonaCorreoDto
            {
                Id = correo.Id,
                IdPersona = correo.IdPersona,
                Correo = correo.Correo,
                EsPrincipal = correo.EsPrincipal,
                UserCreate = correo.UserCreate,
                UserUpdate = correo.UserUpdate,
                DateCreated = correo.DateCreated,
                DateUpdate = correo.DateUpdate
            };
        }

        public static PersonaCorreo ToEntity(this PersonaCorreoDto correoDto)
        {
            return new PersonaCorreo
            {
                Id = correoDto.Id,
                IdPersona = correoDto.IdPersona,
                Correo = correoDto.Correo,
                EsPrincipal = correoDto.EsPrincipal,
                UserCreate = correoDto.UserCreate,
                UserUpdate = correoDto.UserUpdate,
                DateCreated = correoDto.DateCreated,
                DateUpdate = correoDto.DateUpdate
            };
        }

        public static List<PersonaCorreoDto> ToDtoList(this List<PersonaCorreo> correos)
        {
            return correos.Select(p => p.ToDto()).ToList();
        }
    }
}

