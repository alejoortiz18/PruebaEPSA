using EpsaBLL;
using EpsaEntities.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace EpsaAPI.Controllers
{
    public class ConsumoPorClienteController : ApiController
    {
        private HistoriaConsumoPorClienteBLL _consumoPorClienteBLL;

        #region CONSTRUCTOR 

        private ConsumoPorClienteController()
        {
            _consumoPorClienteBLL = new HistoriaConsumoPorClienteBLL();
        }
        #endregion

        #region METODOS PARA CONSULTAR 
        /// <summary>
        /// <br/>Control de Cambios-----------------
        /// <br/>EJERCICIO:    Request 2
        /// <br/> PLANTEAMIENTO: Histórico Consumos por Cliente (Residencial, Comercial, Industrial)
        ///<br/>--Se envía una fecha inicial y una final (yyyy-MM-dd) y se debe de responder 
        ///<br/>--con una historia por cada tipo de usuario, que contenga el tramo, consumo, perdidas
        ///<br/>--y costo por el consumo. Esta historia permite ver cual tramo genera mayores perdidas para tomar decisiones.
        /// <br/>Creado:         Julio. 16/2023
        /// <br/>Modificado:     
        /// <br/>Version:        1.0
        /// <br/>Autor:          RAOG(mi empresa) - René Alejandro Ortiz Gaviria
        /// <br/>Sistema:        EpsaAPI Bussines
        /// <br/>Assemblies:     EpsaAPI.EpsaBLL.Bussines
        /// <br/>Description:    Metodo para Obtener Histórico Consumos por Cliente (Residencial, Comercial, Industrial) filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerHistoriaConsumoDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación método ConsumoPorTramo
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        [ResponseType(typeof(ObtenerHistoriaConsumoDto))]
        [Route("ConsumoPorTramo")]
        public IHttpActionResult ConsumoPorTramo(FechasDto date)
        {

            List<ObtenerHistoriaConsumoDto> ohc = new List<ObtenerHistoriaConsumoDto>();
            if (!ModelState.IsValid)
            {
                var msn = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                return Ok(msn);
            }
            ohc = _consumoPorClienteBLL.ObtenerHistoria(date);
            return Ok(ohc);
        }
        #endregion
    }
}
