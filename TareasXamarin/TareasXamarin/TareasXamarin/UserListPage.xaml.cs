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

            myToolbarItem.Clicked += async (sender, e) =>
            {
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
                await Navigation.PushAsync(new UserPage() { BindingContext = e.SelectedItem as Models.User });
            }
        }
    }
}