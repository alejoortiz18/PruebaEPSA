using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.Models
{
    public class CostoPorTramo
    {
        public int IdTramo_Linea { get; set; }
        public DateTime Fecha { get; set; }
        public double Residencial_CostoWH { get; set; }
        public double Comercial_CostoWH { get; set; }
        public double Industrial_CostoWH { get; set; }
    }
}
