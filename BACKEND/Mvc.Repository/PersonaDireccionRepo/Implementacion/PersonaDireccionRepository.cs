using DbModel.demoDb;
using DtoModel.PersonaDireccion;
using Microsoft.EntityFrameworkCore;
using Mvc.Repository.PersonaDireccionRepo.Contratos;
using Mvc.Repository.PersonaDireccionRepo.Mapping;

namespace Mvc.Repository.PersonaDireccionRepo.Implementacion
{
    public class PersonaDireccionRepository : IPersonaDireccionRepository
    {
        private readonly _demoContext _db;

        public PersonaDireccionRepository(_demoContext db)
        {
            _db = db;
        }

        public async Task<PersonaDireccionDto> Create(PersonaDireccionDto request)
        {
            PersonaDireccion entity = request.ToEntity();
            await _db.PersonaDireccion.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            await _db.PersonaDireccion.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<PersonaDireccionDto>> GetAll()
        {
            List<PersonaDireccion> data = await _db.PersonaDireccion.ToListAsync();
            return data.ToDtoList();
        }

        public async Task<PersonaDireccionDto?> GetById(int id)
        {
            PersonaDireccion? entity = await _db.PersonaDireccion.Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity?.ToDto();
        }

        public async Task<List<PersonaDireccionDto>> GetByPersonaId(int personaId)
        {
            List<PersonaDireccion> data = await _db.PersonaDireccion.Where(x => x.IdPersona == personaId).ToListAsync();
            return data.ToDtoList();
        }

        public async Task<PersonaDireccionDto> Update(PersonaDireccionDto request)
        {
            var entity = await _db.PersonaDireccion.FindAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dirección no encontrada");
            }

            entity.IdPersona = request.IdPersona;
            entity.Tipo = request.Tipo;
            entity.Direccion = request.Direccion;
            entity.Ciudad = request.Ciudad;
            entity.Region = request.Region;
            entity.CodigoPostal = request.CodigoPostal;
            entity.UserUpdate = request.UserUpdate;
            entity.DateUpdate = request.DateUpdate;

            await _db.SaveChangesAsync();
            return entity.ToDto();
        }
    }
}

