using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_app.Helpers;
using xamarin_app.ViewModels;

namespace xamarin_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        protected override async void OnAppearing()
        {
            try
            {
                // Look for existing account
                IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

                AuthenticationResult result = await App.AuthenticationClient
                    .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();

                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            catch
            {
                // Do nothing - the user isn't logged in
            }
            base.OnAppearing();
        }
    }
}