using dal.pagafacil;
using generales.ef;
using modelo;
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

    public class PagoController : ApiController
    {
        /// <summary>
        /// Realiza la recarga de saldo por la cuenta especificada hacia la aplicación móvil
        /// </summary>
        /// <param name="recarga"></param>
        /// <returns></returns>

        [Route("recarga")]
        [HttpPost]
        [ResponseType(typeof(Response))]
        public HttpResponseMessage recarga(Transaccion recarga)
        {
            Response resp = new Response();
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            bool procesado = false;
            using (var contextoTransaccion = contexto.Database.BeginTransaction())
            {
                try
                {
                    tpagmovimiento mov = TpagMovimientoDal.crear(1, 1, recarga.cuentadest, recarga.monto);
                    procesado = TpagCuentaDal.crear(mov);
                    contexto.SaveChanges();
                    contextoTransaccion.Commit();
                    resp.mensaje = "PROCESADO CORRECTAMENTE";
                }
                catch (Exception ex)
                {
                    contextoTransaccion.Rollback();
                    resp.status = 400;
                    resp.mensaje = ex.Message;
                }
                finally {
                    Session.CerrarContexto(contexto);
                }



            }

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

            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            List<tpagtransaccion> lista= TpagTransacccionDal.lista();          

            return GetResponse(lista);

        }
        /// <summary>
        /// Realiza el pago en una transacción
        /// </summary>
        /// <param name="pago"></param>
        /// <returns></returns>
        [Route("transferencia")]
        [HttpPost]
        [ResponseType(typeof(Response))]
        public HttpResponseMessage pago(Transaccion pago)
        {

            Response resp = new Response();
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            bool procesado = false;
            using (var contextoTransaccion = contexto.Database.BeginTransaction())
            {
                try
                {
                    tpagmovimiento mov = TpagMovimientoDal.crear(1, pago.cuentaorg, pago.cuentadest, pago.monto);
                    procesado = TpagCuentaDal.crear(mov);
                    contexto.SaveChanges();
                    contextoTransaccion.Commit();
                    resp.mensaje = "PROCESADO CORRECTAMENTE";

                }
                catch (Exception ex)
                {
                    resp.status = 400;
                    resp.mensaje = ex.Message;
                    contextoTransaccion.Rollback();
                }
                finally
                {
                    Session.CerrarContexto(contexto);
                }



            }

            return GetResponse(procesado);


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
