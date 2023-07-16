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
            ohc = _consumoPorTramoBLL.ObtenerHistoriaConsumo(date);
            return Ok(ohc);
        }
        #endregion
    }
}
