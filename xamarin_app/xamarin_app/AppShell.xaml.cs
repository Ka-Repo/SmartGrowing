using System;
using System.Collections.Generic;
using Xamarin.Forms;
using xamarin_app.ViewModels;
using xamarin_app.Views;

namespace xamarin_app
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
