using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamarin_app.Models;
using xamarin_app.Services;

namespace xamarin_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private Plant _activePlant;
        public static int plantIndex = 0;

        public ObservableCollection<Plant> Plants { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Plant> ItemTapped { get; }
        public ICommand LogoutCommand { get; }

        public Plant ActivePlant
        {
            get => _activePlant;
            set => SetProperty(ref _activePlant, value);
        }

        public AboutViewModel()
        {
            Plants = new ObservableCollection<Plant>();
            LogoutCommand = new Command(async () => await AuthService.Logout());

            Task.Run(async () => await ExecuteLoadItemsCommand());

            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Task.Run(async () => await ExecuteLoadItemsCommand());
                return true;
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Plants.Clear();
                var plants = await CosmosDBService.GetPlants();
                foreach (var plant in plants)
                {
                    Plants.Add(plant);
                }

                ActivePlant = plants[plantIndex];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;        }
    }
}


