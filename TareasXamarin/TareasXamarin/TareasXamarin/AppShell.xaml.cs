using System;
using System.Collections.Generic;
using TareasXamarin.ViewModels;
using TareasXamarin.Views;
using Xamarin.Forms;

namespace TareasXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
