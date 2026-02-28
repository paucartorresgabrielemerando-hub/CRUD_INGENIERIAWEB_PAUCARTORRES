using DtoModel.PersonaDireccion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Bussnies.PersonaDireccion;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonaDireccionController : ControllerBase
    {
        private readonly IPersonaDireccionBussnies _bussnies;

        public PersonaDireccionController(IPersonaDireccionBussnies bussnies)
        {
            _bussnies = bussnies;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaDireccionDto>>> GetAll([FromQuery] int? personaId)
        {
            if (personaId.HasValue)
            {
                return Ok(await _bussnies.GetByPersonaId(personaId.Value));
            }

            return Ok(await _bussnies.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDireccionDto>> GetById(int id)
        {
            PersonaDireccionDto? entity = await _bussnies.GetById(id);
            if (entity == null)
            {
                return NotFound(new { message = "Dirección no encontrada" });
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDireccionDto>> Create([FromBody] PersonaDireccionDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaDireccionDto created = await _bussnies.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<PersonaDireccionDto>> Update([FromBody] PersonaDireccionDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaDireccionDto? updated = await _bussnies.Update(request);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PersonaDireccionDto? entity = await _bussnies.GetById(id);
            if (entity == null)
            {
                return NotFound(new { message = "Dirección no encontrada" });
            }

            await _bussnies.Delete(id);
            return NoContent();
        }
    }
}

