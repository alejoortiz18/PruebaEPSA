using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.Models
{
    public class ConsumoPorTramo
    {
        public int IdTramo_Linea { get; set; }
        public DateTime Fecha { get; set; }
        public int ResidencialWH { get; set; }
        public int ComercialWH { get; set; }
        public int IndustrialWH { get; set; }
    }
}
