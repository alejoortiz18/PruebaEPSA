using EpsaBLL;
using EpsaEntities.ModelDto;
using Microsoft.Ajax.Utilities;
using Swagger.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace EpsaAPI.Controllers
{
    public class ConsumoPorTramoController : ApiController
    {
        private ConsumoPorTramoBLL _consumoPorTramoBLL;

        #region CONSTRUCTOR 

        private ConsumoPorTramoController()
        {
            _consumoPorTramoBLL = new ConsumoPorTramoBLL();
        }
        #endregion

        #region METODOS PARA CONSULTAR 
        /// <summary>
        /// <br/>Control de Cambios-----------------
        /// <br/>EJERCICIO:    Request 1
        /// <br/> PLANTEAMIENTO: Histórico Consumos por Cliente (Residencial, Comercial, Industrial)
        ///<br/>Se envía una fecha inicial y una final(yyyy-MM-dd)
        ///<br/>y se debe de responder con una historia por cada tramo, 
        ///<br/>que contenga el consumo, perdidas y costo por el consumo.
        ///<br/>Esto permite dar una contextualización al cliente de como
        ///<br/>han estado los datos en ese periodo de tiempo.
        /// <br/>Creado:         Julio. 16/2023
        /// <br/>Modificado:     
        /// <br/>Version:        1.0
        /// <br/>Autor:          RAOG(mi empresa) - René Alejandro Ortiz Gaviria
        /// <br/>Sistema:        EpsaAPI Bussines
        /// <br/>Assemblies:     EpsaAPI.EpsaBLL.Bussines
        /// <br/>Description:    Metodo para Obtener Historial de consumo de todos los tramos filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerHistoriaConsumoDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación Clase ConsumoPorTramoDAL
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        [ResponseType(typeof(ObtenerHistorialTramosDto))]
        [Route("ConsumoPorTramo")]
        public IHttpActionResult ConsumoPorTramo(FechasDto date)
        {
           
            List<ObtenerHistorialTramosDto> ohc = new List<ObtenerHistorialTramosDto>();
            if (!ModelState.IsValid)
            {
                var msn = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                return Ok(msn);
            }
            ohc = _consumoPorTramoBLL.ObtenerHistoriaConsumo(date);
            return Ok(ohc);
        }
        #endregion
    }
}
