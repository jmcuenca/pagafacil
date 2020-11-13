using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCore.Models
{
    public class Transaccion
    {
       public int transaccion { get; set; }
        public decimal monto { get; set; }
        public string usuario { get; set; }
        public string codigo { get; set; }

    }
}