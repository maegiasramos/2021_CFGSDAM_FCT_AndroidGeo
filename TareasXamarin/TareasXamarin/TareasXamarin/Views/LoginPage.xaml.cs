using System;
using System.Threading.Tasks;
using TareasXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace TareasXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        // Método que se llamará al pulsar el botón
        async void LoginButton(object sender, EventArgs e)
        {
            bool userExists = App.UserDatabase.GetExistingUser(Username.Text, Password.Text);

            // Comprueba que los campos de usuario y contraseña NO estén vacíos
            // if (Username.Text != null && Password.Text != null)
            if (!String.IsNullOrEmpty(Username.Text) && !String.IsNullOrEmpty(Password.Text))
            {
                // Pasa a comprobar si usuario y contraseña introducidos existen ya
                if (userExists)
                {
                    Models.User selectedUser = App.UserDatabase.GetSelectedUser(Username.Text, Password.Text);
                    Application.Current.Properties["LoggedUserID"] = selectedUser.UserID;

                    await Navigation.PushAsync(new Views.TabbedMenu());
                }
                else
                {
                    // TODO Toast user not found
                    Console.WriteLine("No se ha podido conectar correctamente. Por favor, inténtelo de nuevo.");
                }
            }
            else
            {
                // TODO Toast empty field
                Console.WriteLine("No puedes dejar campos en blanco. Inténtalo de nuevo rellenando los datos.");
            }
        }

        // Método que permite crear un nuevo usuario desde la pantalla de login
        async void New_Account(object sender, EventArgs e)
        {
            // Accede a la página de usuario en modo Nuevo Usuario
            Application.Current.Properties["UserMode"] = "New";
            await Navigation.PushAsync(new UserPage() { BindingContext = new Models.User() });
        }
    }
}