using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xamarin_app.Models;
using xamarin_app.ViewModels;

namespace xamarin_app.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Plant Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            this.BindingContext = new NewItemViewModel();
        }
    }
}