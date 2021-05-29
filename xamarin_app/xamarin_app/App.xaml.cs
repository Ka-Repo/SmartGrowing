using Microsoft.Identity.Client;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_app.Helpers;
using xamarin_app.Services;
using xamarin_app.Views;

namespace xamarin_app
{
    public partial class App : Application
    {
        public static IPublicClientApplication AuthenticationClient { get; private set; }

        public static object UIParent { get; set; } = null;

        public App()
        {
            InitializeComponent();

            AuthenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
                .WithIosKeychainSecurityGroup(Constants.IosKeychainSecurityGroups)
                .WithB2CAuthority(Constants.AuthoritySignin)
                .WithRedirectUri($"msal{Constants.ClientId}://auth")
                .Build();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
