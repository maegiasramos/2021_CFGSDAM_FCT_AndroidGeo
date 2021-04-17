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
    public partial class EventListPage : ContentPage
    {
        public EventListPage()
        {
            InitializeComponent();
            this.Title = "Lista de Eventos";

            var myToolbarItem = new ToolbarItem
            {
                Text = "+"
            };

            myToolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new EventPage() { BindingContext = new Models.User() });
            };

            ToolbarItems.Add(myToolbarItem);
        }

        // Sobreescribe el método OnAppearing de la vista UserListPage
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            EventListView.ItemsSource = await App.UserDatabase.GetUsersAsync();
        }

        async void Event_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EventPage() { BindingContext = e.SelectedItem as Models.Eventos });
            }
        }
    }
}