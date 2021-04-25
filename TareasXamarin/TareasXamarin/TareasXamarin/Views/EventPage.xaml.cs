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
    }
}