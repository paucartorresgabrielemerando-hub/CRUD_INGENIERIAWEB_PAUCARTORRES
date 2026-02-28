using DtoModel.PersonaEmpleo;

namespace Mvc.Bussnies.PersonaEmpleo
{
    public interface IPersonaEmpleoBussnies
    {
        Task<List<PersonaEmpleoDto>> GetAll();
        Task<List<PersonaEmpleoDto>> GetByPersonaId(int personaId);
        Task<PersonaEmpleoDto?> GetById(int id);
        Task<PersonaEmpleoDto> Create(PersonaEmpleoDto request);
        Task<PersonaEmpleoDto?> Update(PersonaEmpleoDto request);
        Task Delete(int id);
    }
}

