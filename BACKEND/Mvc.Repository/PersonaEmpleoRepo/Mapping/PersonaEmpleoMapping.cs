using DbModel.demoDb;
using DtoModel.PersonaEmpleo;

namespace Mvc.Repository.PersonaEmpleoRepo.Mapping
{
    public static class PersonaEmpleoMapping
    {
        public static PersonaEmpleoDto ToDto(this PersonaEmpleo empleo)
        {
            return new PersonaEmpleoDto
            {
                Id = empleo.Id,
                IdPersona = empleo.IdPersona,
                Empresa = empleo.Empresa,
                Cargo = empleo.Cargo,
                FechaInicio = empleo.FechaInicio,
                FechaFin = empleo.FechaFin,
                Salario = empleo.Salario,
                UserCreate = empleo.UserCreate,
                UserUpdate = empleo.UserUpdate,
                DateCreated = empleo.DateCreated,
                DateUpdate = empleo.DateUpdate
            };
        }

        public static PersonaEmpleo ToEntity(this PersonaEmpleoDto empleoDto)
        {
            return new PersonaEmpleo
            {
                Id = empleoDto.Id,
                IdPersona = empleoDto.IdPersona,
                Empresa = empleoDto.Empresa,
                Cargo = empleoDto.Cargo,
                FechaInicio = empleoDto.FechaInicio,
                FechaFin = empleoDto.FechaFin,
                Salario = empleoDto.Salario,
                UserCreate = empleoDto.UserCreate,
                UserUpdate = empleoDto.UserUpdate,
                DateCreated = empleoDto.DateCreated,
                DateUpdate = empleoDto.DateUpdate
            };
        }

        public static List<PersonaEmpleoDto> ToDtoList(this List<PersonaEmpleo> empleos)
        {
            return empleos.Select(p => p.ToDto()).ToList();
        }
    }
}

