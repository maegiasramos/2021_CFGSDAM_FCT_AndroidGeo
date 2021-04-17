using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMenu : TabbedPage
    {
        public TabbedMenu()
        {
            // Añadimos las páginas al TabbedMenu
            this.Children.Add(new LoginPage() { Title = "Iniciar sesión" });
            this.Children.Add(new UserListPage() { Title = "Lista de usuarios" });
            InitializeComponent();
        }
    }
}