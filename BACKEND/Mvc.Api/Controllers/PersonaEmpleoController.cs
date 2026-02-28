using DtoModel.PersonaEmpleo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Bussnies.PersonaEmpleo;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonaEmpleoController : ControllerBase
    {
        private readonly IPersonaEmpleoBussnies _bussnies;

        public PersonaEmpleoController(IPersonaEmpleoBussnies bussnies)
        {
            _bussnies = bussnies;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaEmpleoDto>>> GetAll([FromQuery] int? personaId)
        {
            if (personaId.HasValue)
            {
                return Ok(await _bussnies.GetByPersonaId(personaId.Value));
            }

            return Ok(await _bussnies.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaEmpleoDto>> GetById(int id)
        {
            PersonaEmpleoDto? entity = await _bussnies.GetById(id);
            if (entity == null)
            {
                return NotFound(new { message = "Empleo no encontrado" });
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<PersonaEmpleoDto>> Create([FromBody] PersonaEmpleoDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaEmpleoDto created = await _bussnies.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<PersonaEmpleoDto>> Update([FromBody] PersonaEmpleoDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaEmpleoDto? updated = await _bussnies.Update(request);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PersonaEmpleoDto? entity = await _bussnies.GetById(id);
            if (entity == null)
            {
                return NotFound(new { message = "Empleo no encontrado" });
            }

            await _bussnies.Delete(id);
            return NoContent();
        }
    }
}

