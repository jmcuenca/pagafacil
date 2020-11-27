using pagafacil.paginas.ayuda;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pagafacil.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalMaster : ContentPage
    {
        public ListView ListView;

        public PaginaPrincipalMaster()
        {
            InitializeComponent();

            BindingContext = new PaginaPrincipalMasterViewModel();
            ListView = MenuItemsListView;
        }

        class PaginaPrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PaginaPrincipalMenuItem> MenuItems { get; set; }
            
            public PaginaPrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<PaginaPrincipalMenuItem>(new[]
                {
                    new PaginaPrincipalMenuItem { Id = 0, Title = "Billetera" },
                    new PaginaPrincipalMenuItem { Id = 1, Title = "Consultas" },
                    new PaginaPrincipalMenuItem (typeof(Ayuda)){ Id = 2, Title = "Ayuda",  },
                    new PaginaPrincipalMenuItem { Id = 3, Title = "Términos" },
                    new PaginaPrincipalMenuItem { Id = 4, Title = "Salir" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}