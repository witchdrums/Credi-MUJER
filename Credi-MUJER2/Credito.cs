using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credi_MUJER2
{
    internal class Credito
    {
        public string TipoNegocio { set; get; }
        public string Producto { set; get; }
        public string Ingresos { set; get; }
        public int Prestamo { set; get; }
        public int PlazoEnAnios { set; get; }

        public Credito()
        {
            TipoNegocio = "N/A";
            Producto= "N/A";
            Ingresos= "N/A";
            Prestamo = 0;
            PlazoEnAnios = 0;
        }
        
    }
}
