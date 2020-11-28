using dal.pagafacil;
using generales.ef;
using modelo;
using modelo.interfaces;
using Newtonsoft.Json;
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
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Consulta del saldo del cliente
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>

        [Route("saldo")]
        [HttpPost]
        [ResponseType(typeof(Response))]
        public HttpResponseMessage saldo(Consulta consulta)
        {
            Response resp = new Response();
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            tpagcuenta cuenta = TpagCuentaDal.buscar(consulta.identificacion);
            resp.registro = cuenta;            
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
        public HttpResponseMessage movimientos(Consulta consulta)
        {

            Response resp = new Response();
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            List<tpagmovimiento> movimientos = TpagMovimientoDal.buscar(consulta.identificacion);
            List<IBean> reg = new List<IBean>();
            foreach (tpagmovimiento mov in movimientos) {
                IBean b = (IBean)mov;
                reg.Add(b);
            }
            resp.lregistros = reg;
            
            return GetResponse(resp);

        }
        /// <summary>
        /// Consulta de movimientos en el sistema por fechas
        /// </summary>
        /// <param name="consultaFecha"></param>
        /// <returns></returns>
        [Route("movimientosFecha")]
        [HttpPost]
        [ResponseType(typeof(List<tpagmovimiento>))]
        public HttpResponseMessage movimientosfecha(ConsultaFecha consultaFecha)
        {

            Response resp = new Response();
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            List<tpagmovimiento> movimientos = TpagMovimientoDal.buscar(consultaFecha.identificacion,consultaFecha.finicio,consultaFecha.ffin);
            List<IBean> reg = new List<IBean>();
            foreach (tpagmovimiento mov in movimientos)
            {
                IBean b = (IBean)mov;
                reg.Add(b);
            }
            resp.lregistros = reg;

            return GetResponse(resp);

        }
        private HttpResponseMessage GetResponse(object resp)
        {
            string conten = JsonConvert.SerializeObject(resp);
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(conten)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }
    }
}
