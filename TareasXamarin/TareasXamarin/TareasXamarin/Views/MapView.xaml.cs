using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TareasXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();
        }

        // Modificamos método OnAppearing para pasarle las coordenadas a nuestro mapa
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Guardamos nuestras coordenadas en un objeto tipo Position de Xamarin.Forms.Maps
            Position pos = new Position(40.5164475, -3.7345538);
            // Creamos un nuevo "Pin" (marcador) para mostrar el lugar de la ubicación señalado en el mapa
            Pin pin = new Pin
            {
                Position = pos,
                Label = "Nombre Ubicación",
                Type = PinType.Place
            };
            // Añadimos el "Pin" a la lista de marcadores que debe mostrar el elemento mapa
            this.mylocalmap.Pins.Add(pin);

            // Desplazamos la vista del mapa para encajar el marcador creado en ella
            if(Device.RuntimePlatform == Device.Android)
            {
                Task.Delay(2000).ContinueWith(task => Device.BeginInvokeOnMainThread(() => this.mylocalmap.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(0.5)))));
            }
            else
            {
                this.mylocalmap.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(0.5)));
            }
        }
    }
}