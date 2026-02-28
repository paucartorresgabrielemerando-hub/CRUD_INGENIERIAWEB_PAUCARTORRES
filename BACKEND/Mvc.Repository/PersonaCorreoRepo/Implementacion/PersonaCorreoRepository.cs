using DbModel.demoDb;
using DtoModel.PersonaCorreo;
using Microsoft.EntityFrameworkCore;
using Mvc.Repository.PersonaCorreoRepo.Contratos;
using Mvc.Repository.PersonaCorreoRepo.Mapping;

namespace Mvc.Repository.PersonaCorreoRepo.Implementacion
{
    public class PersonaCorreoRepository : IPersonaCorreoRepository
    {
        private readonly _demoContext _db;

        public PersonaCorreoRepository(_demoContext db)
        {
            _db = db;
        }

        public async Task<PersonaCorreoDto> Create(PersonaCorreoDto request)
        {
            PersonaCorreo entity = request.ToEntity();
            await _db.PersonaCorreo.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            await _db.PersonaCorreo.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<PersonaCorreoDto>> GetAll()
        {
            List<PersonaCorreo> data = await _db.PersonaCorreo.ToListAsync();
            return data.ToDtoList();
        }

        public async Task<PersonaCorreoDto?> GetById(int id)
        {
            PersonaCorreo? entity = await _db.PersonaCorreo.Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity?.ToDto();
        }

        public async Task<List<PersonaCorreoDto>> GetByPersonaId(int personaId)
        {
            List<PersonaCorreo> data = await _db.PersonaCorreo.Where(x => x.IdPersona == personaId).ToListAsync();
            return data.ToDtoList();
        }

        public async Task<PersonaCorreoDto> Update(PersonaCorreoDto request)
        {
            var entity = await _db.PersonaCorreo.FindAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Correo no encontrado");
            }

            entity.IdPersona = request.IdPersona;
            entity.Correo = request.Correo;
            entity.EsPrincipal = request.EsPrincipal;
            entity.UserUpdate = request.UserUpdate;
            entity.DateUpdate = request.DateUpdate;

            await _db.SaveChangesAsync();
            return entity.ToDto();
        }
    }
}

