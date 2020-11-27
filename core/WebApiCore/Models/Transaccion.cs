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
        public long cuentaorg { get; set; }
        public long cuentadest { get; set; }
        

    }
}