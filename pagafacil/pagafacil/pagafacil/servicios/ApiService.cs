using Android.Renderscripts;
using Android.Util;
using Newtonsoft.Json;
using pagafacil.interfaces;
using pagafacil.modelo;
using pagafacil.modelo.entidades;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pagafacil.servicios
{
    public class ApiService : IApi
    {
        private readonly IApi _api;
        public RestClient cliente;
        public static string Url = "http://2cf4cb8c9123.ngrok.io/api";
        private HttpClient _Client = new HttpClient();
        Response resp;
        public ApiService()
        {
            cliente = new RestClient(new Uri(Url));
            resp = new Response();
        }

        public  async Task<Response>  consumir(string des, dynamic parametros) {
            var content = await _Client.PostAsync(Url+ "/ingresar" new HttpContent({);
           return resp=  JsonConvert.DeserializeObject<Response>(content);

        }


        public  async Task<Response> login(Usuario us)
        {         
            byte[] dato = consumir("/ingresar", us);
            string hola = "ss";

            return JsonConvert.DeserializeObject<Response>(hola);
        }

        public async Task<Response> registro(tsegusuario us)
        {
           
            var request = new RestRequest("/ingresar", Method.POST);
            request.AddJsonBody(us);
            var resp = await cliente.ExecuteAsync<Response>(request);
            return resp.Data;
        }

        public Task<Response> recarga(Transaccion us)
        {
            return _api.recarga(us);
        }

        public Task<Response> transacciones()
        {
            return _api.transacciones();
        }

        public Task<Response> transferencia(Transaccion us)
        {
            return _api.transferencia(us);
        }

        public Task<Response> saldo(Consulta us)
        {
            return _api.saldo(us);
        }

        public Task<Response> movimientos(Consulta us)
        {
            return _api.movimientos(us);
        }

        public Task<Response> movimientosFecha(Consulta us)
        {
            return _api.movimientos(us);
        }
    }

}
