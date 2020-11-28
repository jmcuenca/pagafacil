using System;
using System.Collections.Generic;
using System.Text;

namespace pagafacil.modelo
{
  public  class Response
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public Object registro { get; set; }
        public List<object> lregistros { get; set; }


    }
}
