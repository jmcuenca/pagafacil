using generales.ef;
using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.pagafacil
{
   public static class TpagTransacccionDal
    {
        public static List<tpagtransaccion> lista() {
            coreContext contexto = Session.GetContexto();
            List<tpagtransaccion> lst = contexto.tpagtransaccion.ToList();
            return lst;
        }
        public static tpagtransaccion buscar(long ctransaccion)
        {
            coreContext contexto = Session.GetContexto();
            tpagtransaccion lst = contexto.tpagtransaccion.Where(x => x.ctransaccion == ctransaccion).FirstOrDefault();
            return lst;
        }
    }
}
