using dal.pagafacil;
using dal.seguridad;
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
using System.Web.UI.WebControls;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [RoutePrefix("api")]

    public class LoginController : ApiController
    {
        /// <summary>
        /// Realiza el ingreso a la aplicación
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [Route("ingreso")]
        [HttpPost]
        [ResponseType(typeof(Response))]
        public HttpResponseMessage login(Usuario Usuario)
        {
            Response resp = new Response();
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            tsegusuario us = TsegUsuarioDal.busqueda(Usuario.usuario);
            if (us == null)
            {
                resp.mensaje = "USUARIO NO ENCONTRADO";
                us = null;
            }
            else {
                if (us.clave.Equals(Usuario.clave))
                {
                    resp.mensaje = "INGRESO EXITOSO";
                    resp.registro = us;
                }
                else {
                    resp.mensaje = "CLAVE INCORRECTA";
                }
            }      

            return GetResponse(resp);

        }
        [Route("registro")]
        [HttpPost]
        [ResponseType(typeof(Response))]
        public HttpResponseMessage registro(tsegusuario Usuario)
        {
            Response resp = new Response();

            tsegusuario us;
            coreContext contexto = new coreContext();
            Session.FijarContexto(contexto);
            using (var contextoTransaccion = contexto.Database.BeginTransaction())
            {
                try
                {
                    us = TsegUsuarioDal.busqueda(Usuario.identificacion);
                    if (us == null)
                    {
                        Usuario.cusuario = TsegUsuarioDal.id();
                        tpagcuenta cuenta = new tpagcuenta();
                        cuenta.cuenta = TpagCuentaDal.id();
                        cuenta.cusuario = Usuario.cusuario;
                        cuenta.saldo = 0;
                        cuenta.fultimomov = DateTime.Now;
                        cuenta.moneda = "USD";
                        cuenta.estado = true;
                        tpagmovimiento mov = TpagMovimientoDal.crear(3, cuenta.cuenta, cuenta.cuenta, 0);
                        Session.Grabar(Usuario);
                        Session.Grabar(cuenta);
                        Session.Grabar(mov);
                        contexto.SaveChanges();
                        contextoTransaccion.Commit();
                        resp.mensaje = "CREADO CON ÉXITO";
                        resp.registro = Usuario;

                    }
                    else {
                        resp.status = 400;
                        resp.mensaje = "EL USUARIO CON ESTA IDENTIFICACIÓN YA EXISTE";
                            }

                    
                }
                catch (Exception ex)
                {
                    resp.status = 400;
                    resp.mensaje = ex.Message;
                    contextoTransaccion.Rollback();
                }

                

            }
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
