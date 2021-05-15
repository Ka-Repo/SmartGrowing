using System.ComponentModel;
using Xamarin.Forms;
using xamarin_app.ViewModels;

namespace xamarin_app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}