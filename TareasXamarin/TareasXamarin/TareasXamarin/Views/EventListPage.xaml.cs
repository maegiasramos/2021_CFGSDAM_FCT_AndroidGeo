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
                // Colocamos el modo de acceso a la pestaña de eventos como Nuevo evento
                Application.Current.Properties["EventMode"] = "New";
                await Navigation.PushAsync(new EventPage() { BindingContext = new Models.Eventos() });
            };

            ToolbarItems.Add(myToolbarItem);
        }

        // Sobreescribe el método OnAppearing de la vista EventListPage
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            EventListView.ItemsSource = await App.UserDatabase.GetEventsAsync();
        }

        async void Event_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                // Colocamos el modo de acceso a la pestaña de eventos como Modificar evento
                Application.Current.Properties["EventMode"] = "Modify";

                // Obtenemos la visibilidad y el ID de Propietario del Evento seleccionado para controlar su acceso y modificación
                var retrievedObject = e.SelectedItem as Models.Eventos;
                var visibility = retrievedObject.Visibility;
                var ownerID = retrievedObject.OwnerID;
                // Guardamos la visibilidad y el ID de Propietario en Propiedades de la App para
                // poder realizar comprobaciones en la pestaña del Evento
                Application.Current.Properties["VisibilityMode"] = visibility;
                Application.Current.Properties["EventOwnerID"] = ownerID;

                //Console.WriteLine(Application.Current.Properties["VisibilityMode"].ToString());

                await Navigation.PushAsync(new EventPage() { BindingContext = e.SelectedItem as Models.Eventos });
            }
        }
    }
}