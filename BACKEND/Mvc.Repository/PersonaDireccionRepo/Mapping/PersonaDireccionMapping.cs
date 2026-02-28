using DbModel.demoDb;
using DtoModel.PersonaDireccion;

namespace Mvc.Repository.PersonaDireccionRepo.Mapping
{
    public static class PersonaDireccionMapping
    {
        public static PersonaDireccionDto ToDto(this PersonaDireccion direccion)
        {
            return new PersonaDireccionDto
            {
                Id = direccion.Id,
                IdPersona = direccion.IdPersona,
                Tipo = direccion.Tipo,
                Direccion = direccion.Direccion,
                Ciudad = direccion.Ciudad,
                Region = direccion.Region,
                CodigoPostal = direccion.CodigoPostal,
                UserCreate = direccion.UserCreate,
                UserUpdate = direccion.UserUpdate,
                DateCreated = direccion.DateCreated,
                DateUpdate = direccion.DateUpdate
            };
        }

        public static PersonaDireccion ToEntity(this PersonaDireccionDto direccionDto)
        {
            return new PersonaDireccion
            {
                Id = direccionDto.Id,
                IdPersona = direccionDto.IdPersona,
                Tipo = direccionDto.Tipo,
                Direccion = direccionDto.Direccion,
                Ciudad = direccionDto.Ciudad,
                Region = direccionDto.Region,
                CodigoPostal = direccionDto.CodigoPostal,
                UserCreate = direccionDto.UserCreate,
                UserUpdate = direccionDto.UserUpdate,
                DateCreated = direccionDto.DateCreated,
                DateUpdate = direccionDto.DateUpdate
            };
        }

        public static List<PersonaDireccionDto> ToDtoList(this List<PersonaDireccion> direcciones)
        {
            return direcciones.Select(p => p.ToDto()).ToList();
        }
    }
}

