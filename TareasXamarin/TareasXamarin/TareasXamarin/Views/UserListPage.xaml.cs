using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        public UserListPage()
        {
            InitializeComponent();
            this.Title = "Lista de Usuarios";

            var myToolbarItem = new ToolbarItem
            {
                Text = "+"
            };

            // Listener al pulsar el botón de Añadir usuario ("+")
            myToolbarItem.Clicked += async (sender, e) =>
            {
                // Coloca el modo en Nuevo usuario al acceder desde el botón +
                Application.Current.Properties["UserMode"] = "New";
                await Navigation.PushAsync(new UserPage() { BindingContext = new Models.User() });
            };

            ToolbarItems.Add(myToolbarItem);
        }

        // Sobreescribe el método OnAppearing de la vista UserListPage
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserListView.ItemsSource = await App.UserDatabase.GetUsersAsync();
        }

        async void User_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                // Coloca el modo en modificar al acceder desde la lista de usuarios.
                Application.Current.Properties["UserMode"] = "Modify";
                await Navigation.PushAsync(new UserPage() { BindingContext = e.SelectedItem as Models.User });
            }
        }
    }
}