using System.Windows.Input;
using Xamarin.Forms;
using xamarin_app.Services;
using xamarin_app.Views;

namespace xamarin_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand LogoutCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command((async () => await Shell.Current.GoToAsync($"//{nameof(AboutPage)}")));
            LogoutCommand = new Command(async () => await AuthService.Login());
        }
    }
}
