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
            InitializeComponent();
            // Añadimos las páginas al TabbedMenu
            this.Children.Add(new UserListPage() { Title = "Lista de usuarios" });
            this.Children.Add(new EventListPage() { Title = "Lista de tareas" });
        }
    }
}