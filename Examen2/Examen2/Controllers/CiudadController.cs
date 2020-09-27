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
    public class CiudadController:ControllerBase
    {
        private readonly CiudadanoDataContext _baseDatos;
        private readonly CiudadAppService _ciudadAppService;

        public CiudadController(CiudadanoDataContext context, CiudadAppService ciudadAppService)
        {
            _baseDatos = context;
            _ciudadAppService = ciudadAppService;

            if (_baseDatos.Ciudads.Count() == 0)
            {
                _baseDatos.Ciudads.Add(new Ciudad { nombre_ciudad="San Pedro Sula" ,descripcion="Grande"});
                _baseDatos.Ciudads.Add(new Ciudad { nombre_ciudad = "Copan", descripcion = "Mediana" });
                _baseDatos.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudad()
        {
            return await _baseDatos.Ciudads.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudad>> GetCiudad(int id)
        {
            var respuestaCiudadAppService = await _ciudadAppService.GetCiudadApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaCiudadAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return await _baseDatos.Ciudads.FirstOrDefaultAsync(q => q.id == id);
            }
            return BadRequest(respuestaCiudadAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Ciudad>> PostCiudad(Ciudad Ciudad)
        {

            var respuestaCiudadAppService = await _ciudadAppService.PostCiudadApplicationService(Ciudad);
            
            bool noHayErroresEnLasValidaciones = respuestaCiudadAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetCiudad), new { id = Ciudad.id }, Ciudad);
            }
            return BadRequest(respuestaCiudadAppService);
        }

        [HttpPost("rango")]

        public async Task<ActionResult<Ciudad>> PostCiudad(IEnumerable<Ciudad> Ciudad)
        {
            _baseDatos.Ciudads.AddRange(Ciudad);
            await _baseDatos.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCiudad), Ciudad);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudad(int id, Ciudad Ciudad)
        {
            var ciudad = await _baseDatos.Ciudads.FindAsync(id);

            var respuestaCudadanoAppService = await _ciudadAppService.PuttCiudadApplicationService(id,Ciudad);

            bool noHayErroresEnLasValidaciones = respuestaCudadanoAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaCudadanoAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudad(int id,Ciudad ciudad)
        {
            var respuestaCiudadAppService = await _ciudadAppService.DeleteCiudadApplicationService(id,ciudad);

            bool noHayErroresEnLasValidaciones = respuestaCiudadAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaCiudadAppService);
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteAutolote(IEnumerable<int> ids)
        {
            IEnumerable<Ciudad> Ciudads = _baseDatos.Ciudads.Where(q => ids.Contains(q.id));
            if (Ciudads== null)
            {
                return NotFound();
            }
            _baseDatos.Ciudads.RemoveRange(Ciudads);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }
    }
}
