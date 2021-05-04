using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TareasXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
        }

        // Método asociado al botón de guardar evento
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Crea un objeto de tipo Evento y le pasa los valores introducidos
            var eventItem = (Models.Eventos)BindingContext;
            // Guarda el usuario en la base de datos
            await App.UserDatabase.SaveEventAsync(eventItem);
            // Navega de nuevo a la ventana de lista de usuarios
            await Navigation.PopAsync(); 
        }

        // Método asociado al botón de cancelar
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Método asociado al botón de eliminar evento
        async void Delete_Clicked(object sender, EventArgs e)
        {
            // Crea un objeto de tipo User y le pasa los valores introducidos
            var eventItem = (Models.Eventos)BindingContext;
            // Guarda el usuario en la base de datos
            await App.UserDatabase.DeleteEventAsync(eventItem);
            // Navega de nuevo a la ventana de lista de usuarios
            await Navigation.PopAsync();
        }

        // Método que obtiene las coordenadas de un punto a partir del nombre de la ubicación con Geocoding
        async void Geocoding_Method(object sender, EventArgs e)
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(LocationName.Text);
                if (result.Any())
                    LocationName.Text = $"{result.FirstOrDefault()?.Latitude}, {result.FirstOrDefault()?.Longitude}";
            }
            catch(FeatureNotSupportedException notsupportedex)
            {
                // TODO Añadir Toast que indique que esta función no está disponible en este dispositivo 
            }
            catch(Exception ex)
            {
                // TODO Añadir Toast que indique que algo salió mal
            }
        }

        // Método que obtiene el nombre de la ubicación a partir de las coordenadas de un punto con Geocoding
        async void ReverseGeocoding_Method(object sender, EventArgs e)
        {
            try
            {
                double lat;
                double lng;

                lat = Convert.ToDouble(LocationName.Text.Split(',')[0]);
                lng = Convert.ToDouble(LocationName.Text.Split(',')[1]);

                var result = await Geocoding.GetPlacemarksAsync(lat, lng);

                if (result.Any())
                    LocationName.Text = result.FirstOrDefault()?.FeatureName;
            }
            catch (FeatureNotSupportedException notsupportedex)
            {
                // TODO Añadir Toast que indique que esta función no está disponible en este dispositivo 
            }
            catch (Exception ex)
            {
                // TODO Añadir Toast que indique que algo salió mal
            }
        }

        async void ViewMap(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.MapView());
        }
    }
}