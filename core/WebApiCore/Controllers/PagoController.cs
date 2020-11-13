using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [RoutePrefix("api")]

    public class PagoController : ApiController
    {
        /// <summary>
        /// Realiza la recarga de saldo por la cuenta especificada hacia la aplicación móvil
        /// </summary>
        /// <param name="recarga"></param>
        /// <returns></returns>

        [Route("recarga")]
        [HttpPost]
        [ResponseType(typeof(List<tpagmovimiento>))]
        public HttpResponseMessage recarga(Transaccion recarga)
        {

            string resp = "";

            return GetResponse(resp);

        }
        /// <summary>
        /// Realiza una transacción en especifico
        /// </summary>
        /// <returns></returns>
        
        [Route("transacciones")]
        [HttpGet]
        [ResponseType(typeof(List<tpagtransaccion>))]
        public HttpResponseMessage transacciones()
        {

            string resp = "";

            return GetResponse(resp);

        }
        /// <summary>
        /// Realiza el pago en una transacción
        /// </summary>
        /// <param name="pago"></param>
        /// <returns></returns>
        [Route("pago")]
        [HttpPost]
        [ResponseType(typeof(List<tpagmovimiento>))]
        public HttpResponseMessage pago(Transaccion pago)
        {

            string resp = "";

            return GetResponse(resp);

        }

        private HttpResponseMessage GetResponse(string resp)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(resp)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }

    }

}
