using pagafacil.interfaces;
using pagafacil.paginas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace pagafacil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Properties["loging"] = false;
            MainPage = new NavigationPage(new PaginaPrincipal());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void ShowMainPage()
        {
            
        }

        public void salir()
        {
            
        }
    }
}
