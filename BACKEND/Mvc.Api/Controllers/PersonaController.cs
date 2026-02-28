using DbModel.demoDb;
using DtoModel.Persona;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Bussnies.Persona;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonaController : ControllerBase
    {

        private readonly IPersonaBussnies _personaBussnies;
        private readonly _demoContext _db;

        public PersonaController(IPersonaBussnies personaBussnies, _demoContext db)
        {
            _personaBussnies = personaBussnies;
            _db = db;
        }


        [HttpGet]
        public async Task<ActionResult<List<PersonaDto>>> GetAll()
        {
            List<PersonaDto> list = await _personaBussnies.GetAll();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> GetById(int id)
        {
            PersonaDto? persona = await _personaBussnies.GetById(id);

            if (persona == null)
            {
                return NotFound(new { message = "Persona no encontrada" });
            }

            return Ok(persona);
        }

        [HttpGet("tipos-documento")]
        public async Task<ActionResult<IEnumerable<object>>> GetTiposDocumento()
        {
            try
            {
                var list = await _db.PersonaTipoDocumento
                    .AsNoTracking()
                    .OrderBy(x => x.Descripcion)
                    .Select(x => new
                    {
                        id = x.Id,
                        codigo = x.Codigo,
                        descripcion = x.Descripcion
                    })
                    .ToListAsync();

                return Ok(list);
            }
            catch (Exception)
            {
                // En caso de cualquier error inesperado devolvemos lista vacía
                // para no romper el frontend ni la aplicación.
                return Ok(Array.Empty<object>());
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDto>> Create([FromBody] PersonaDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaDto persona = await _personaBussnies.Create(request);

            return CreatedAtAction(nameof(GetById), new { id = persona.Id }, persona);
        }

        [HttpPut]
        public async Task<ActionResult<PersonaDto>> Update([FromBody] PersonaDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonaDto? persona = await _personaBussnies.Update(request);

            if (persona == null)
            {
                return NotFound(new { message = "Persona no encontrada" });
            }

            return Ok(persona);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PersonaDto? persona = await _personaBussnies.GetById(id);

            if (persona == null)
            {
                return NotFound(new { message = "Persona no encontrada" });
            }

            await _personaBussnies.Delete(id);

            return NoContent();
        }


    }
}
