using generales.ef;
using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.seguridad
{
  public static  class TsegUsuarioDal
    {
        public static tsegusuario busqueda(string identificacion) {
            coreContext contexto = Session.GetContexto();
            tsegusuario us = contexto.tsegusuario.Where(x => x.identificacion.Equals(identificacion)).FirstOrDefault();
            return us;
        }
        public static long id()
        {
            coreContext contexto = Session.GetContexto();

            long dato = 0;
            tsegusuario eval = contexto.tsegusuario.OrderByDescending(x => x.cusuario).FirstOrDefault();
            if (eval != null)
                long.TryParse(eval.cusuario.ToString(), out dato);
            return (dato+1);

        }

    }
}
