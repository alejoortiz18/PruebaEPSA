using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.ModelDto
{
    public class ObtenerHistoriaConsumoDto
    {
        public string   Tramo { get; set; }
        public DateTime Fecha { get; set; }
        public int      Consumo_Residencial { get; set; }
        public int      Consumo_Comercial { get; set; }
        public int      Consumo_Industrial { get; set; }
        public double   Perdida_Residencial { get; set; }
        public double   Perdida_Comercial { get; set; }
        public double   Perdida_Industrial { get; set; }
        public double   Costo_Consumo_Residencial { get; set; }
        public double   Costo_Consumo_Comercial { get; set; }
        public double   Costo_Consumo_Industrial { get; set; }
    }
}
