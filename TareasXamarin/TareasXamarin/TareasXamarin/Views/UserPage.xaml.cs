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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();

            // Comprueba si el Usuario accede para crear uno nuevo o modificar uno existente
            // con objetivo de cambiar el título de la ventana
            if(Application.Current.Properties["UserMode"].ToString().Equals("New"))
            {
                Title = "Nuevo usuario";
            }
            else if(Application.Current.Properties["UserMode"].ToString().Equals("Modify"))
            {
                Title = "Modificar usuario";
            }
        }

        // Método asociado al botón de guardar usuario
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Crea un objeto de tipo User y le pasa los valores introducidos
            var personItem = (Models.User)BindingContext;
            // Guarda el usuario en la base de datos
            await App.UserDatabase.SaveUserAsync(personItem);
            // Navega de nuevo a la ventana de lista de usuarios
            await Navigation.PopAsync();
        }

        // Método asociado al botón de cancelar
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Método asociado al botón de eliminar usuario
        async void Delete_Clicked(object sender, EventArgs e)
        {
            // Crea un objeto de tipo User y le pasa los valores introducidos
            var personItem = (Models.User)BindingContext;
            // Guarda el usuario en la base de datos
            await App.UserDatabase.DeleteUserAsync(personItem);
            // Navega de nuevo a la ventana de lista de usuarios
            await Navigation.PopAsync();
        }
    }
}