using generales.ef;
using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.pagafacil
{
    public static class TpagMovimientoDal
    {
        public static List<tpagmovimiento> buscar(string identificacion) {
            coreContext contexto = Session.GetContexto();

            var resultado = (from usuario in contexto.tsegusuario
                             join cuenta in contexto.tpagcuenta on usuario.cusuario equals cuenta.cusuario
                             join movimiento in contexto.tpagmovimiento on cuenta.cuenta equals movimiento.cuentades

                             where usuario.identificacion.Equals(identificacion)
                             orderby movimiento.cmovimiento descending
                             select movimiento
                             
               ).Take(20).ToList();
            return resultado;
        }
        public static List<tpagmovimiento> buscar(string identificacion, DateTime finicio, DateTime ffin)
        {
            coreContext contexto = Session.GetContexto();

            var resultado = (from usuario in contexto.tsegusuario
                             join cuenta in contexto.tpagcuenta on usuario.cusuario equals cuenta.cusuario
                             join movimiento in contexto.tpagmovimiento on cuenta.cuenta equals movimiento.cuentades

                             where usuario.identificacion.Equals(identificacion)
                             && (movimiento.fproceso >= finicio && movimiento.fproceso <= ffin)
                             orderby movimiento.cmovimiento descending
                             select movimiento
               ).Take(20).ToList();
            return resultado;
        }
        public static long id()
        {
            coreContext contexto = Session.GetContexto();

            long dato = 0;
            tpagmovimiento eval = contexto.tpagmovimiento.OrderByDescending(x => x.cmovimiento).FirstOrDefault();
            if (eval != null)
                long.TryParse(eval.cmovimiento.ToString(), out dato);

            return (dato + 1);

        }
        public static tpagmovimiento crear(long ctransaccion,long cuentaorg, long cuentades,decimal monto)
        {
            coreContext contexto = Session.GetContexto();
            tpagmovimiento mov = new tpagmovimiento();
            mov.cmovimiento = id();
            mov.cuentaorg = cuentaorg;
            mov.cuentades = cuentades;
            mov.ctransaccion = ctransaccion;
            tpagtransaccion tran = TpagTransacccionDal.buscar(ctransaccion);
            mov.debito = tran.debito.Value;
            mov.monto = monto;
            mov.terminal = "MÓVIL";
        
            mov.descripcion =  tran.nombre + ". CTA. ORG : "+cuentaorg.ToString()+" A LA CUENTA: " + cuentades.ToString();
            mov.fproceso = DateTime.Now;
            return mov;
        }
    }
}
