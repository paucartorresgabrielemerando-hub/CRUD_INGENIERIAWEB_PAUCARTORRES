using DtoModel.PersonaDireccion;
using Mvc.Repository.PersonaDireccionRepo.Contratos;

namespace Mvc.Bussnies.PersonaDireccion
{
    public class PersonaDireccionBussnies : IPersonaDireccionBussnies
    {
        private readonly IPersonaDireccionRepository _repo;

        public PersonaDireccionBussnies(IPersonaDireccionRepository repo)
        {
            _repo = repo;
        }

        public async Task<PersonaDireccionDto> Create(PersonaDireccionDto request)
        {
            return await _repo.Create(request);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<PersonaDireccionDto>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<PersonaDireccionDto?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<PersonaDireccionDto>> GetByPersonaId(int personaId)
        {
            return await _repo.GetByPersonaId(personaId);
        }

        public async Task<PersonaDireccionDto?> Update(PersonaDireccionDto request)
        {
            var exists = await _repo.GetById(request.Id);
            if (exists == null)
            {
                throw new Exception("Dirección a actualizar no existe");
            }

            return await _repo.Update(request);
        }
    }
}

