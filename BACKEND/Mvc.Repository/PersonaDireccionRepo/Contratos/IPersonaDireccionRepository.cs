using DtoModel.PersonaDireccion;
using Mvc.Repository.General.Contratos;

namespace Mvc.Repository.PersonaDireccionRepo.Contratos
{
    public interface IPersonaDireccionRepository : ICrudRepository<PersonaDireccionDto>, IDisposable
    {
        Task<List<PersonaDireccionDto>> GetByPersonaId(int personaId);
    }
}

