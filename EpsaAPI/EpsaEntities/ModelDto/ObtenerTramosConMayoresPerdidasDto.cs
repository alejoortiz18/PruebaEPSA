using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.ModelDto
{
    public class ObtenerTramosConMayoresPerdidasDto
    {
        public string Tramo { get; set; }
        public DateTime Fecha { get; set; }
        public int ResidencialWH { get; set; }
        public int ComercialWH { get; set; }
        public int IndustrialWH { get; set; }
    }
}
