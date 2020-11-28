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
    public partial class PaginaPrincipal : MasterDetailPage
    {
        bool login;
        public PaginaPrincipal()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            login = false;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PaginaPrincipalMenuItem;
            if (item == null)
                return;
            bool.TryParse(App.Current.Properties["loging"].ToString(), out login);
            if (!login)
            {
                Login ingreso = new Login();

                var page = (Page)Activator.CreateInstance(typeof(Login));
                Detail = new NavigationPage(page);
                page.Title = "Ingreso";
                IsPresented = false;
                MasterPage.ListView.SelectedItem = null;
            }
            else
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;

                MasterPage.ListView.SelectedItem = null;
            }
        }
    }
}