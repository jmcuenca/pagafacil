using pagafacil.interfaces;
using pagafacil.modelo;
using pagafacil.modelo.entidades;
using pagafacil.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pagafacil.paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

    

    public partial class Login : ContentPage
	{
        private string _usuario;
        private string _clave;
        IloginManager iml;
        ApiService api;
        tsegusuario usuario;
        Response resp;
        public Login ( )
		{
			InitializeComponent ();
            BindingContext = this;
            resp = new Response();
            api = new ApiService();
            
		}
       public async void btnIngresarClick(object sender,EventArgs args) {
            
          await  login();
           
        }

            
        private async  Task login()
        {

            try
            {
                Usuario us = new Usuario();
                us.usuario = Usuario;
                us.clave = Clave;
                resp = await api.login(us);
                if (resp.status == 200)
                {
                    App.Current.Properties["login"] = true;
                    iml.ShowMainPage();
                }
                else
                {
                    int a = 0;
                    await DisplayAlert("Error", resp.mensaje, "Ok");
                }

            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

        }
        public string Usuario
        {
            get => _usuario;
            set
            {
                if (value == _usuario) return;
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }
        public string Clave
        {
            get => _clave;
            set
            {
                if (value == _clave) return;
                _clave = value;
                OnPropertyChanged(nameof(Clave));
            }
        }
    }
}