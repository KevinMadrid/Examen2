using Examen2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.DomainService
{
    public class CiudadanoDomainService
    {
        public string GetCiudadanoDomainService(int id, Ciudadano ciudadano)
        {
            if (ciudadano == null)
            {
                return "El Ciudadano no Existe";
            }
            return null;
        }

        public string PostCiudadanoDomainService(CiudadanoCiudad ciudadanociudad)
        {
            if (ciudadanociudad.Ciudad == null)
            {
                return "La Ciudad no existe";
            }
            return null;
        }

           public string PutCiudadanoDomainService(int id, CiudadanoCiudad ciudadanociudad)
           {
               if (ciudadanociudad.Ciudadano == null)
               {
                   return "No existe el Ciudadano";
               }
               if (ciudadanociudad.Ciudad == null)
               {
                   return "La Ciudad no existe";
               }
              
               return null;
           }
          public string DeleteCiudadanoDomainService(Ciudadano ciudadano)
           {
               if (ciudadano == null)
               {
                   return "No se Encuentra el Ciudadano";
               }
               return null;
           }
    }


}
