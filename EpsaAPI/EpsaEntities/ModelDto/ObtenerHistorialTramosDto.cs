using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.ModelDto
{
    public class ObtenerHistorialTramosDto
    {
        public int IdTramo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Consumo { get; set; }
        public double Perdidas { get; set; }
        public double Costo { get; set; }
    }
}
