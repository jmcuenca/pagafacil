using generales.ef;
using generales.excepcion;
using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.pagafacil
{
    public static class TpagCuentaDal
    {
       
        public static long id()
        {
            coreContext contexto = Session.GetContexto();

            long dato = 0;
            tpagcuenta eval = contexto.tpagcuenta.OrderByDescending(x => x.cuenta).FirstOrDefault();
            if (eval != null)
                long.TryParse(eval.cuenta.ToString(), out dato);

            return (dato+1);

        }
        public static bool crear(tpagmovimiento mov) {
            coreContext contexto = Session.GetContexto();
            tpagcuenta cuentaorg = contexto.tpagcuenta.Where(x => x.cuenta == mov.cuentaorg).FirstOrDefault();
            tpagcuenta cuentadest = contexto.tpagcuenta.Where(x => x.cuenta == mov.cuentades).FirstOrDefault();
            bool ok = false;
            if (cuentadest == null) {
                throw new CoreException("ERROR", "NO EXISTE LA CUENTA DESTINO");
            }
            if (cuentaorg == null)
            {
                throw new CoreException("ERROR", "NO EXISTE LA CUENTA ORIGEN");
            }
            if (mov.monto <0)
            {
                throw new CoreException("ERROR", "ERROR EN EL MONTO");
            }
            if (cuentaorg.saldo < mov.monto.Value)
            {
                throw new CoreException("ERROR", "SALDO NO DISPONIBLE");

            }
            else {
                tpagmovimiento movorg = TpagMovimientoDal.crear(1, mov.cuentaorg.Value, mov.cuentades.Value,mov.monto.Value);
                tpagmovimiento movdest = TpagMovimientoDal.crear(2, mov.cuentades.Value, mov.cuentaorg.Value, mov.monto.Value);
                movdest.cmovimiento = movorg.cmovimiento + 1;
                cuentaorg.saldo = cuentaorg.saldo - mov.monto;
                cuentadest.saldo = cuentadest.saldo + mov.monto;
                cuentaorg.fultimomov = DateTime.Now;
                cuentadest.fultimomov = DateTime.Now;
                Session.Actualizar(cuentaorg);
                Session.Actualizar(cuentadest);
                Session.Grabar(movorg);
                Session.Grabar(movdest);

                ok = true;
            }

            return ok;

        }
        public static tpagcuenta buscar(string identificacion)
        {

            coreContext contexto = Session.GetContexto();

            var resultado = (from usuario in contexto.tsegusuario
                             join cuenta in contexto.tpagcuenta on usuario.cusuario equals cuenta.cusuario
                             
                             where usuario.identificacion.Equals(identificacion)
                             select cuenta
               ).SingleOrDefault();
            return resultado;
        }

    }
}
