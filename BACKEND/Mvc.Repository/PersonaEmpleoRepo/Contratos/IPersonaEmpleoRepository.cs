using DtoModel.PersonaEmpleo;
using Mvc.Repository.General.Contratos;

namespace Mvc.Repository.PersonaEmpleoRepo.Contratos
{
    public interface IPersonaEmpleoRepository : ICrudRepository<PersonaEmpleoDto>, IDisposable
    {
        Task<List<PersonaEmpleoDto>> GetByPersonaId(int personaId);
    }
}

