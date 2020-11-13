using modelo;
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
        [ResponseType(typeof(tsegusuario))]
        public HttpResponseMessage recarga(Usuario Usuario)
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
