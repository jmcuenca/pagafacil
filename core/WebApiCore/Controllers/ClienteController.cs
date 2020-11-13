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
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Consulta del saldo del cliente
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>

        [Route("saldo")]
        [HttpPost]
        [ResponseType(typeof(tsegusuario))]
        public HttpResponseMessage saldo(Consulta consulta)
        {

            string resp = "";

            return GetResponse(resp);

        }
        /// <summary>
        /// Consulta de movimientos en el sistema
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [Route("movimientos")]
        [HttpPost]
        [ResponseType(typeof(List<tpagmovimiento>))]
        public HttpResponseMessage movimientos(ConsultaFecha consulta)
        {

            string resp = "";

            return GetResponse(resp);

        }
        /// <summary>
        /// Consulta de movimientos en el sistema por fechas
        /// </summary>
        /// <param name="consultaFecha"></param>
        /// <returns></returns>
        [Route("movimientosfecha")]
        [HttpPost]
        [ResponseType(typeof(List<tpagmovimiento>))]
        public HttpResponseMessage movimientosfecha(ConsultaFecha consultaFecha)
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
