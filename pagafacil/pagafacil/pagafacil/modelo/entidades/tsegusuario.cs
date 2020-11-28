using System;
using System.Collections.Generic;
using System.Text;

namespace pagafacil.modelo.entidades
{
   public class tsegusuario
    {
        public long cusuario { get; set; }
        public string nombres { get; set; }
        public string identificacion { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string clave { get; set; }
        public string clavetmp { get; set; }
        public Nullable<bool> estado { get; set; }
    }
}
