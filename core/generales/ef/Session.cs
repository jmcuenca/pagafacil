using modelo;
using modelo.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generales.ef
{
    public class Session
    {
        [ThreadStatic]
        public static coreContext thread_coreContext = null;
        [ThreadStatic]
        public static bool thread_rollback = false;
        public static void FijarContexto(coreContext coreContext)
        {
            Session.thread_rollback = false;
            Session.thread_coreContext = coreContext;
        }
        public static coreContext GetContexto()
        {
            coreContext coreContexto = Session.thread_coreContext;
            return coreContexto;
        }
        public static void CerrarContexto(coreContext thread_CoreContext)
        {
            if (thread_CoreContext != null)
                thread_CoreContext.Dispose();
        }
        
        /// <summary>
        /// Inserta un registro en la base de datos sin generar auditoria ni historicos.
        /// </summary>
        /// <param name="bean">Objeto a inseratar en la base de datos.</param>
        public static void Grabar(IBean bean)
        {
            coreContext coreContext = Session.GetContexto();
            var set = coreContext.Set(bean.GetType());
            set.Add(bean);
            coreContext.Entry(bean).State = System.Data.Entity.EntityState.Added;
        }
        public static void Actualizar(IBean bean)
        {
            coreContext coreContext = Session.GetContexto();
            var set = coreContext.Set(bean.GetType());
            set.Add(bean);
            coreContext.Entry(bean).State = System.Data.Entity.EntityState.Modified;
        }

    }


            }
