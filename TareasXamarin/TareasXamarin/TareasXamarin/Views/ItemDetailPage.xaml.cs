using System.ComponentModel;
using TareasXamarin.ViewModels;
using Xamarin.Forms;

namespace TareasXamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}