using pagafacil.modelo;
using pagafacil.modelo.entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pagafacil.interfaces
{
    public interface IApi
    {
        
        Task<Response>  login(Usuario us);
        
        Task<Response> registro(tsegusuario us);

       
        Task<Response> recarga(Transaccion us);

        Task<Response> transacciones();

        Task<Response> transferencia(Transaccion us);
        Task<Response> saldo(Consulta us);

        Task<Response> movimientos(Consulta us);

        Task<Response> movimientosFecha(Consulta us);
        





    }
}
