using System;
using System.Collections.Generic;
using System.Text;

namespace pagafacil.modelo.entidades
{
    public class tpagmovimiento
    {
        public long cmovimiento { get; set; }
        public Nullable<long> ctransaccion { get; set; }
        public Nullable<long> cuentaorg { get; set; }
        public Nullable<long> cuentades { get; set; }
        public Nullable<decimal> monto { get; set; }
        public Nullable<bool> debito { get; set; }
        public string terminal { get; set; }
        public Nullable<System.DateTime> fproceso { get; set; }
        public string descripcion { get; set; }
    }
}
