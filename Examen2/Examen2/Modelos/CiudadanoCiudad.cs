using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Modelos
{
    public class CiudadanoCiudad
    {
        public CiudadanoCiudad(Ciudadano ciudadano, Ciudad ciudad)
        {
            Ciudadano = ciudadano;
            Ciudad = ciudad;
        }

        public Ciudadano Ciudadano{ get; set; }
        public Ciudad Ciudad{ get; set; }
    }
}
