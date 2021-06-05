using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamarin_app.Services;

namespace xamarin_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            LogoutCommand = new Command(async () => await AuthService.Logout());
        }

        public ICommand LogoutCommand { get; }
    }
}