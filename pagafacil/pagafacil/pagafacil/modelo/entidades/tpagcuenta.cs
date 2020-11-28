using System;
using System.Collections.Generic;
using System.Text;

namespace pagafacil.modelo.entidades
{
    class tpagcuenta
    {
        public long cuenta { get; set; }
        public Nullable<long> cusuario { get; set; }
        public Nullable<decimal> saldo { get; set; }
        public Nullable<System.DateTime> fultimomov { get; set; }
        public string moneda { get; set; }
        public Nullable<bool> estado { get; set; }

    }
}
