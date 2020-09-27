using Microsoft.EntityFrameworkCore;
using Examen2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen2.DomainService;
namespace Examen2.ApplicationServices
{
    public class CiudadanoAppService
    {
        private readonly CiudadanoDataContext _baseDatos;
        private readonly CiudadanoDomainService _ciudadanoDomainService;

        public CiudadanoAppService(CiudadanoDataContext _context, CiudadanoDomainService ciudadanoDomainService) 
        {
            _baseDatos = _context;
            _ciudadanoDomainService = ciudadanoDomainService;

        }

        public async Task<String> GetCiudadanoApplicationService(int id)
        {
            var Ciudadano = await _baseDatos.Ciudadanos.Include(q => q.ciudad).FirstOrDefaultAsync(q => q.id == id);
           
            var respuestaDomainService = _ciudadanoDomainService.GetCiudadanoDomainService(id,Ciudadano);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null ;
        }

        public async Task<String> PostCiudadanoApplicationService(Ciudadano ciudadano )
        {
            CiudadanoCiudad ciudadanociudad = await LlamadaALaBaseDeDatos(ciudadano);

            var respuestaDomainService = _ciudadanoDomainService.PostCiudadanoDomainService(ciudadanociudad);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Ciudadanos.Add(ciudadano);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        
        public async Task<String> PuttCiudadanoApplicationService(int id, Ciudadano ciudadano)
        {
            CiudadanoCiudad ciudadanociudad = await LlamadaALaBaseDeDatos(ciudadano);

            var respuestaDomainService = _ciudadanoDomainService.PutCiudadanoDomainService(id, ciudadanociudad);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(ciudadano).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }

        private async Task<CiudadanoCiudad> LlamadaALaBaseDeDatos(Ciudadano ciudadano)
        {
            Ciudad ciudad = await _baseDatos.Ciudads.FirstOrDefaultAsync(q => q.id == ciudadano.ciudadid);

            var ciudadanociudad = new CiudadanoCiudad(ciudadano, ciudad);
            return ciudadanociudad;
        }

        public async Task<String> DeleteCiudadanoApplicationService(int id)
        {
            var ciudadano = await _baseDatos.Ciudadanos.FindAsync(id);


            var respuestaDomainService = _ciudadanoDomainService.DeleteCiudadanoDomainService(ciudadano);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Ciudadanos.Remove(ciudadano);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
