using EpsaDAL;
using EpsaEntities.ModelDto;
using System;
using System.Collections.Generic;

namespace EpsaBLL
{
    public class ConsumoPorTramoBLL
    {
        private ConsumoPorTramoDAL _cptDal;

        public ConsumoPorTramoBLL()
        {
            _cptDal = new ConsumoPorTramoDAL();
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
        /// <br/>Description:    Metodo para Obtener Historial por Tramos filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerHistorialTramosDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación Clase ConsumoPorTramoDAL
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        public List<ObtenerHistorialTramosDto> ObtenerHistoria(FechasDto fecha)
        {
            List<ObtenerHistorialTramosDto> result = _cptDal.ObtenerHistoria(fecha);
            return result;
        }

        /// <summary>
        /// <br/>Control de Cambios-----------------
        /// <br/>Compania:       
        /// <br/>Creado:         Julio. 16/2023
        /// <br/>Modificado:     
        /// <br/>Version:        1.0
        /// <br/>Autor:          RAOG(mi empresa) - René Alejandro Ortiz Gaviria
        /// <br/>Sistema:        EpsaAPI Bussines
        /// <br/>Assemblies:     EpsaAPI.EpsaBLL.Bussines
        /// <br/>Description:    Metodo para Obtener Historial Peores Tramos/Cliente filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerTramosConMayoresPerdidasDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación Clase ConsumoPorTramoDAL
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        public List<ObtenerTramosConMayoresPerdidasDto> ListaTramosConMayorPerdida(FechasDto fecha)
        {
            List<ObtenerTramosConMayoresPerdidasDto> result = _cptDal.ListaTramosConMayorPerdida(fecha);
            return result;
        }

        #endregion
    }
}
