using DtoModel.PersonaEmpleo;
using Mvc.Repository.PersonaEmpleoRepo.Contratos;

namespace Mvc.Bussnies.PersonaEmpleo
{
    public class PersonaEmpleoBussnies : IPersonaEmpleoBussnies
    {
        private readonly IPersonaEmpleoRepository _repo;

        public PersonaEmpleoBussnies(IPersonaEmpleoRepository repo)
        {
            _repo = repo;
        }

        public async Task<PersonaEmpleoDto> Create(PersonaEmpleoDto request)
        {
            return await _repo.Create(request);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<PersonaEmpleoDto>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<PersonaEmpleoDto?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<PersonaEmpleoDto>> GetByPersonaId(int personaId)
        {
            return await _repo.GetByPersonaId(personaId);
        }

        public async Task<PersonaEmpleoDto?> Update(PersonaEmpleoDto request)
        {
            var exists = await _repo.GetById(request.Id);
            if (exists == null)
            {
                throw new Exception("Empleo a actualizar no existe");
            }

            return await _repo.Update(request);
        }
    }
}

