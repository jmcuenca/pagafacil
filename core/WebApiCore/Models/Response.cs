using modelo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCore.Models
{
    public class Response
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public IBean registro { get; set; }
        public List<IBean> lregistros { get; set; }
        public Response() {
            this.status = 200;
            this.mensaje = "OK";

        }
        public void toLregistros(List<IBean> ldatos) {
            this.lregistros = ldatos;
        }
    }
}