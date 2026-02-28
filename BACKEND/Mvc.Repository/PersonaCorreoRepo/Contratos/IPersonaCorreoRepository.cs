using DtoModel.PersonaCorreo;
using Mvc.Repository.General.Contratos;

namespace Mvc.Repository.PersonaCorreoRepo.Contratos
{
    public interface IPersonaCorreoRepository : ICrudRepository<PersonaCorreoDto>, IDisposable
    {
        Task<List<PersonaCorreoDto>> GetByPersonaId(int personaId);
    }
}

