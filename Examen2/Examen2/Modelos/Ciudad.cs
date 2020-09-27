using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Modelos
{
    public class Ciudad
    {
        public int id { get; set; }
        public string nombre_ciudad { get; set; }
        public string descripcion { get; set; }
        public List<Ciudadano> ciudadanos{ get; set; }

    }
}
