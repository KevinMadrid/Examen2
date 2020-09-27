using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Modelos
{
    public class Ciudadano
    {
        public int id { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string foto_ciudadano { get; set; }
        public string numero_telefono { get; set; }
        public int ciudadid { get; set; }
        public Ciudad ciudad { get; set; }

    }
}
