using DtoModel.PersonaCorreo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Bussnies.PersonaCorreo;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonaCorreoController : ControllerBase
    {
        private readonly IPersonaCorreoBussnies _bussnies;

        public PersonaCorreoController(IPersonaCorreoBussnies bussnies)
        {
            _bussnies = bussnies;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaCorreoDto>>> GetAll([FromQuery] int? personaId)
        {
            if (personaId.HasValue)
            {
                return Ok(await _bussnies.GetByPersonaId(personaId.Value));
            }

            return Ok(await _bussnies.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaCorreoDto>> GetById(int id)
        {
            PersonaCorreoDto? entity = await _bussnies.GetById(id);
            if (entity == null)
            {
                return NotFound(new { message = "Correo no encontrado" });
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<PersonaCorreoDto>> Create([FromBody] PersonaCorreoDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaCorreoDto created = await _bussnies.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<PersonaCorreoDto>> Update([FromBody] PersonaCorreoDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaCorreoDto? updated = await _bussnies.Update(request);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PersonaCorreoDto? entity = await _bussnies.GetById(id);
            if (entity == null)
            {
                return NotFound(new { message = "Correo no encontrado" });
            }

            await _bussnies.Delete(id);
            return NoContent();
        }
    }
}

