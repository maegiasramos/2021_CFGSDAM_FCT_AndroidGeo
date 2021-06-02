using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TareasXamarin.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MyToastService))]
namespace TareasXamarin.Droid
{
    public class MyToastService : ToastInterface
    {
        public void Show(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}