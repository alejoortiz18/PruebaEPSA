using EpsaDAL;
using EpsaEntities.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaBLL
{
    public class HistoriaConsumoPorClienteBLL
    {
        private HistoriaConsumoPorClienteDAL _cptDal;

        public HistoriaConsumoPorClienteBLL()
        {
            _cptDal = new HistoriaConsumoPorClienteDAL();
        }


        #region METODOS PARA CONSULTAR 
        /// <summary>
        /// <br/>Control de Cambios-----------------
        /// <br/>Compania:       
        /// <br/>Creado:         Julio. 16/2023
        /// <br/>Modificado:     
        /// <br/>Version:        1.0
        /// <br/>Autor:          RAOG(mi empresa) - René Alejandro Ortiz Gaviria
        /// <br/>Sistema:        EpsaAPI Bussines
        /// <br/>Assemblies:     EpsaAPI.EpsaBLL.Bussines
        /// <br/>Description:    Metodo para Obtener Historial de consumo por Tramos filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerHistoriaConsumoDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación método ObtenerHistoria
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        public List<ObtenerHistoriaConsumoDto> ObtenerHistoria(FechasDto fecha)
        {
            List<ObtenerHistoriaConsumoDto> result = _cptDal.ObtenerHistoria(fecha);
            return result;
        }
        #endregion
    }
}
