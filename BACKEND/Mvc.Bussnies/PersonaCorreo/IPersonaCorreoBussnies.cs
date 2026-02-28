using DtoModel.PersonaCorreo;

namespace Mvc.Bussnies.PersonaCorreo
{
    public interface IPersonaCorreoBussnies
    {
        Task<List<PersonaCorreoDto>> GetAll();
        Task<List<PersonaCorreoDto>> GetByPersonaId(int personaId);
        Task<PersonaCorreoDto?> GetById(int id);
        Task<PersonaCorreoDto> Create(PersonaCorreoDto request);
        Task<PersonaCorreoDto?> Update(PersonaCorreoDto request);
        Task Delete(int id);
    }
}

