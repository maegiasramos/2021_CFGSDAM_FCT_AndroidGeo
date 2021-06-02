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

            // Comprobamos el modo en el que se accede a esta pestaña (Nuevo evento o modificar)
            if (Application.Current.Properties["EventMode"].ToString().Equals("New"))
            {
                Title = "Nuevo evento";

                // Asignamos el ID actual al campo de texto de ID Propietario
                Owner.Text = Application.Current.Properties["LoggedUserID"].ToString();
                // Desactivamos el botón de Eliminar evento al crear uno nuevo (ya que no tiene sentido)
                DeleteButton.IsEnabled = false;
            }
            else if (Application.Current.Properties["EventMode"].ToString().Equals("Modify"))
            {
                Title = "Modificar evento";

                // Comprobamos visibilidad del evento (Público=0, Privado=1 a nivel interno de objeto en BD)
                if (Application.Current.Properties["VisibilityMode"].ToString().Equals("1"))
                {
                    // Comprobamos si el ID Propietario coincide con el ID del usuario actualmente conectado en caso de ser PRIVADO
                    if (!Application.Current.Properties["LoggedUserID"].ToString().Equals(Application.Current.Properties["EventOwnerID"].ToString()))
                    {
                        // Toast aviso de Evento privado y usuario sin permisos sobre el mismo
                        DependencyService.Get<ToastInterface>().Show("Este evento es Privado. No tienes permisos para modificarlo.");

                        // Deshabilitamos entradas de texto y botones para evitar que pueda modificar pero que pueda ver el contenido del Evento
                        Name.IsEnabled = false;
                        Description.IsEnabled = false;
                        Visibility.IsEnabled = false;
                        LocationName.IsEnabled = false;
                        LocationButton.IsEnabled = false;
                        SaveButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;

                        // Cambiamos colores de fondo y letras para que el evento siga siendo legible
                        BackColor.BackgroundColor = Color.CornflowerBlue.MultiplyAlpha(0.5);
                        Owner.TextColor = Color.DimGray;
                        NameLabel.TextColor = Color.DimGray;
                        DescriptionLabel.TextColor = Color.DimGray;
                        VisibilityLabel.TextColor = Color.DimGray;
                        OwnerLabel.TextColor = Color.DimGray;
                        LocationLabel.TextColor = Color.DimGray;
                    }
                }
            }
        }

        // Método asociado al botón de guardar evento
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Comprobamos que ningún valor de texto esté nulo
            if(!String.IsNullOrEmpty(Name.Text) && !String.IsNullOrEmpty(Description.Text) && !String.IsNullOrEmpty(LocationName.Text))
            {
                if(Visibility.SelectedIndex != -1)
                {
                    // Crea un objeto de tipo Evento y le pasa los valores introducidos
                    var eventItem = (Models.Eventos)BindingContext;
                    // En caso de que estemos creando un nuevo Evento, guarda el ID de su propietario.
                    // En caso de que ya exista, no se sobreescribirá.
                    if (Application.Current.Properties["EventMode"].ToString().Equals("New"))
                        eventItem.OwnerID = Application.Current.Properties["LoggedUserID"].ToString();
                    // Guarda el usuario en la base de datos
                    await App.UserDatabase.SaveEventAsync(eventItem);
                    // Navega de nuevo a la ventana de lista de usuarios
                    await Navigation.PopAsync();
                }
                else
                {
                    // Toast error sin seleccionar visibilidad
                    DependencyService.Get<ToastInterface>().Show("Por favor, selecciona la visibilidad del evento.");
                }
            }
            else
            {
                // Toast campos en blanco
                DependencyService.Get<ToastInterface>().Show("Debes rellenar todos los campos para poder guardar el evento.");
            }
            
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
            if (!String.IsNullOrEmpty(LocationName.Text))
            {
                try
                {
                    var result = await Geocoding.GetLocationsAsync(LocationName.Text);
                    if (result.Any())
                    {
                        Application.Current.Properties["Location"] = LocationName.Text;
                        Application.Current.Properties["Latitude"] = result.FirstOrDefault()?.Latitude;
                        Application.Current.Properties["Longitude"] = result.FirstOrDefault()?.Longitude;
                        // En caso de que no haya habido errores muestra la ubicación en el mapa.
                        await Navigation.PushAsync(new Views.MapView());
                    }

                }
                catch (FeatureNotSupportedException)
                {
                    // Toast que indica que esta función no está disponible en este dispositivo 
                    DependencyService.Get<ToastInterface>().Show("Error: función no disponible en este dispositivo.");
                }
                catch (Exception)
                {
                    // Toast que indica que algo salió mal
                    DependencyService.Get<ToastInterface>().Show("Algo salió mal. Por favor, inténtalo de nuevo.");
                }
            }
            else
            {
                // Toast rellenar ubicación
                DependencyService.Get<ToastInterface>().Show("Debes introducir una ubicación antes de buscar en el mapa.");
            }
            
        }
    }
}