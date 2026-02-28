using DbModel.demoDb;
using DtoModel.PersonaEmpleo;
using Microsoft.EntityFrameworkCore;
using Mvc.Repository.PersonaEmpleoRepo.Contratos;
using Mvc.Repository.PersonaEmpleoRepo.Mapping;

namespace Mvc.Repository.PersonaEmpleoRepo.Implementacion
{
    public class PersonaEmpleoRepository : IPersonaEmpleoRepository
    {
        private readonly _demoContext _db;

        public PersonaEmpleoRepository(_demoContext db)
        {
            _db = db;
        }

        public async Task<PersonaEmpleoDto> Create(PersonaEmpleoDto request)
        {
            PersonaEmpleo entity = request.ToEntity();
            await _db.PersonaEmpleo.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            await _db.PersonaEmpleo.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<PersonaEmpleoDto>> GetAll()
        {
            List<PersonaEmpleo> data = await _db.PersonaEmpleo.ToListAsync();
            return data.ToDtoList();
        }

        public async Task<PersonaEmpleoDto?> GetById(int id)
        {
            PersonaEmpleo? entity = await _db.PersonaEmpleo.Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity?.ToDto();
        }

        public async Task<List<PersonaEmpleoDto>> GetByPersonaId(int personaId)
        {
            List<PersonaEmpleo> data = await _db.PersonaEmpleo.Where(x => x.IdPersona == personaId).ToListAsync();
            return data.ToDtoList();
        }

        public async Task<PersonaEmpleoDto> Update(PersonaEmpleoDto request)
        {
            var entity = await _db.PersonaEmpleo.FindAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Empleo no encontrado");
            }

            entity.IdPersona = request.IdPersona;
            entity.Empresa = request.Empresa;
            entity.Cargo = request.Cargo;
            entity.FechaInicio = request.FechaInicio;
            entity.FechaFin = request.FechaFin;
            entity.Salario = request.Salario;
            entity.UserUpdate = request.UserUpdate;
            entity.DateUpdate = request.DateUpdate;

            await _db.SaveChangesAsync();
            return entity.ToDto();
        }
    }
}

