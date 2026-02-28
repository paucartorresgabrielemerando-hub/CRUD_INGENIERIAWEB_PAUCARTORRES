using DbModel.demoDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonaTipoDocumentoController : ControllerBase
    {
        private readonly _demoContext _db;

        public PersonaTipoDocumentoController(_demoContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaTipoDocumento>>> GetAll()
        {
            var list = await _db.PersonaTipoDocumento
                .OrderBy(x => x.Descripcion)
                .ToListAsync();

            return Ok(list);
        }
    }
}

