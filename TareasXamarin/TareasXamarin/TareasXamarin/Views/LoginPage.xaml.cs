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

            if (userExists)
            {
                Models.User selectedUser = App.UserDatabase.GetSelectedUser(Username.Text, Password.Text);
                Application.Current.Properties["LoggedUserID"] = selectedUser.UserID;

                await Navigation.PushAsync(new Views.TabbedMenu());
            }
            else
            {
                // TODO Toast user not found
                Console.WriteLine("Usuario no encontrado");
            }

        }
    }
}