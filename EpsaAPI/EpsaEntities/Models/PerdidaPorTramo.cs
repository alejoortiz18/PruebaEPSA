using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.Models
{
    public class PerdidaPorTramo
    {
        public int IdTramo_Linea { get; set; }
        public DateTime Fecha { get; set; }
        public double Residencial_Porcentaje { get; set; }
        public double Comercial_Porcentaje { get; set; }
        public double Industrial_Porcentaje { get; set; }
    }
}
