using DtoModel.PersonaCorreo;
using Mvc.Repository.PersonaCorreoRepo.Contratos;

namespace Mvc.Bussnies.PersonaCorreo
{
    public class PersonaCorreoBussnies : IPersonaCorreoBussnies
    {
        private readonly IPersonaCorreoRepository _repo;

        public PersonaCorreoBussnies(IPersonaCorreoRepository repo)
        {
            _repo = repo;
        }

        public async Task<PersonaCorreoDto> Create(PersonaCorreoDto request)
        {
            return await _repo.Create(request);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<PersonaCorreoDto>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<PersonaCorreoDto?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<PersonaCorreoDto>> GetByPersonaId(int personaId)
        {
            return await _repo.GetByPersonaId(personaId);
        }

        public async Task<PersonaCorreoDto?> Update(PersonaCorreoDto request)
        {
            var exists = await _repo.GetById(request.Id);
            if (exists == null)
            {
                throw new Exception("Correo a actualizar no existe");
            }

            return await _repo.Update(request);
        }
    }
}

