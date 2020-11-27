using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generales.excepcion
{
    public class CoreException : Exception
    {
        public string Codigo { get; set; }
        public object[] parametros;

        public CoreException(string codigo, string mensaje) : base(mensaje)
        {
            this.Codigo = codigo;
        }

        public CoreException(string codigo, string mensaje, params object[] parametros) : base(mensaje)
        {
            this.Codigo = codigo;
            this.parametros = parametros;
        }
        public CoreException(string codigo, string mensaje, System.Exception inner, params object[] parametros) : base(mensaje, inner)
        {
            this.Codigo = codigo;
            this.parametros = parametros;
        }
    }
}
