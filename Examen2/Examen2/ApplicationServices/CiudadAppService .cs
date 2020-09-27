using Microsoft.EntityFrameworkCore;
using Examen2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen2.DomainService;
namespace Examen2.ApplicationServices
{
    public class CiudadAppService
    {
        private readonly CiudadanoDataContext _baseDatos;
        private readonly CiudadDomainService _ciudadDomainService;

        public CiudadAppService(CiudadanoDataContext _context, CiudadDomainService ciudadDomainService) 
        {
            _baseDatos = _context;
            _ciudadDomainService = ciudadDomainService;

        }

        public async Task<String> GetCiudadApplicationService(int id)
        {
            var ciudad = await _baseDatos.Ciudads.FirstOrDefaultAsync(q => q.id == id);
           
            var respuestaDomainService = _ciudadDomainService.GetCiudadDomainService(ciudad);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null ;
        }

        public async Task<String> PostCiudadApplicationService(Ciudad ciudad)
        {

            var respuestaDomainService = _ciudadDomainService.PostCiudadDomainService(ciudad);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Ciudads.Add(ciudad);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        
        public async Task<String> PuttCiudadApplicationService(int id, Ciudad ciudad)
        {
            var respuestaDomainService = _ciudadDomainService.PutCiudadDomainService(id, ciudad);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(ciudad).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }

        public async Task<String> DeleteCiudadApplicationService(int id,Ciudad ciudad)
        {

            var respuestaDomainService = _ciudadDomainService.DeleteCiudadDomainService(ciudad);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Ciudads.Remove(ciudad);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
