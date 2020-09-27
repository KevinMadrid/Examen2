using Examen2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.DomainService
{
    public class CiudadDomainService
    {
        public string GetCiudadDomainService(Ciudad ciudad)
        {
            if (ciudad == null)
            {
                return "La Ciudad no Existe";
            }
            return null;
        }

        public string PostCiudadDomainService(Ciudad ciudad)
        {
            return null;
        }

           public string PutCiudadDomainService(int id, Ciudad ciudad)
           {
               if (ciudad == null)
               {
                   return "No existe la Ciudad";
               }             
               return null;
           }
          public string DeleteCiudadDomainService(Ciudad ciudad)
           {
               if (ciudad == null)
               {
                   return "La Ciudad no Existe";
               }
               return null;
           }
    }


}
