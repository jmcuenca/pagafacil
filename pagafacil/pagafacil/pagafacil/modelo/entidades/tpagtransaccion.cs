using System;
using System.Collections.Generic;
using System.Text;

namespace pagafacil.modelo.entidades
{
    public class tpagtransaccion
    {
        public long ctransaccion { get; set; }
        public string nombre { get; set; }
        public Nullable<bool> debito { get; set; }
        public string abr { get; set; }

    }
}
