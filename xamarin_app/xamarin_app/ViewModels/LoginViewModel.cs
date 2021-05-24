﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using xamarin_app.Views;

namespace xamarin_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        private async void OnLoginClicked(object obj) => await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    }
}
