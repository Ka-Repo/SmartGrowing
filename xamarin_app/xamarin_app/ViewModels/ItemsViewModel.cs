﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

using xamarin_app.Models;
using xamarin_app.Services;
using xamarin_app.Views;

namespace xamarin_app.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Plant _selectedItem;

        public ObservableCollection<Plant> Plants { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Plant> ItemTapped { get; }

        public ItemsViewModel()
        {
            Plants = new ObservableCollection<Plant>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Plant>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            // if (IsBusy)
            //    return;

            IsBusy = true;

            try
            {
                Plants.Clear();
                var plants = await CosmosDBService.GetPlants();
                foreach (var plant in plants)
                {
                    Plants.Add(plant);
                }
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
            IsBusy = true;
            SelectedItem = null;
        }

        public Plant SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Plant item)
        {
            if (item == null)
                return;

            AboutViewModel.plantIndex = Plants.IndexOf(item);

            // This will push the ItemDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}