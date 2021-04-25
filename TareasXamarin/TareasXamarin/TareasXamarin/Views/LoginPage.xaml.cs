using System;
using TareasXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        private void LoginButton(object sender, EventArgs e)
        {
            LoginConfirmAsync((SelectedItemChangedEventArgs)e);
        }

        // Método que cambiará de página y comprobará si los datos de login son correctos (TODO)
        private async System.Threading.Tasks.Task LoginConfirmAsync(SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EventPage() { BindingContext = e.SelectedItem as Models.Eventos });
        }
    }
}