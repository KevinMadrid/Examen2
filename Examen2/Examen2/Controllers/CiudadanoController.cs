using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Examen2.Modelos;
using Examen2.DataContext;
using Examen2.ApplicationServices;

namespace Examen2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CiudadanoController:ControllerBase
    {
        private readonly CiudadanoDataContext _baseDatos;
        private readonly CiudadanoAppService _ciudadanoAppService;

        public CiudadanoController(CiudadanoDataContext context, CiudadanoAppService ciudadanoAppService)
        {
            _baseDatos = context;
            _ciudadanoAppService = ciudadanoAppService;

            if (_baseDatos.Ciudadanos.Count() == 0)
            {
                _baseDatos.Ciudadanos.Add(new Ciudadano { primer_nombre = "Juan", segundo_nombre= "Fernando",primer_apellido="Garcia",segundo_apellido="Lopez",foto_ciudadano="a",numero_telefono="98452014",ciudadid=1 });
                _baseDatos.Ciudadanos.Add(new Ciudadano { primer_nombre = "Maria", segundo_nombre = "Juana", primer_apellido = "Lopez", segundo_apellido = "Flores", foto_ciudadano = "v", numero_telefono = "31568410", ciudadid = 2 });
                _baseDatos.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudadano>>> GetCiudadano()
        {
            return await _baseDatos.Ciudadanos.Include(q => q.ciudad).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudadano>> GetCiudadano(int id)
        {
            var respuestaCiudadanoAppService = await _ciudadanoAppService.GetCiudadanoApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaCiudadanoAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return await _baseDatos.Ciudadanos.FirstOrDefaultAsync(q => q.id == id);
            }
            return BadRequest(respuestaCiudadanoAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Ciudadano>> PostCiudadano(Ciudadano ciudadano)
        {

            var respuestaCiudadanoAppService = await _ciudadanoAppService.PostCiudadanoApplicationService(ciudadano);
            
            bool noHayErroresEnLasValidaciones = respuestaCiudadanoAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetCiudadano), new { id = ciudadano.id }, ciudadano);
            }
            return BadRequest(respuestaCiudadanoAppService);
        }

        [HttpPost("rango")]

        public async Task<ActionResult<Ciudadano>> PostCiudadano(IEnumerable<Ciudadano> ciudadano)
        {
            _baseDatos.Ciudadanos.AddRange(ciudadano);
            await _baseDatos.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCiudadano), ciudadano);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudadano(int id, Ciudadano ciudadano)
        {
            var ciudad = await _baseDatos.Ciudads.FindAsync(id);

            var respuestaCudadanoAppService = await _ciudadanoAppService.PuttCiudadanoApplicationService(id,ciudadano);

            bool noHayErroresEnLasValidaciones = respuestaCudadanoAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaCudadanoAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudadano(int id)
        {
            var respuestaCiudadanoAppService = await _ciudadanoAppService.DeleteCiudadanoApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaCiudadanoAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaCiudadanoAppService);
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteAutolote(IEnumerable<int> ids)
        {
            IEnumerable<Ciudadano> ciudadanos = _baseDatos.Ciudadanos.Where(q => ids.Contains(q.id));
            if (ciudadanos== null)
            {
                return NotFound();
            }
            _baseDatos.Ciudadanos.RemoveRange(ciudadanos);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }
    }
}
