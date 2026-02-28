using DtoModel.PersonaDireccion;

namespace Mvc.Bussnies.PersonaDireccion
{
    public interface IPersonaDireccionBussnies
    {
        Task<List<PersonaDireccionDto>> GetAll();
        Task<List<PersonaDireccionDto>> GetByPersonaId(int personaId);
        Task<PersonaDireccionDto?> GetById(int id);
        Task<PersonaDireccionDto> Create(PersonaDireccionDto request);
        Task<PersonaDireccionDto?> Update(PersonaDireccionDto request);
        Task Delete(int id);
    }
}

