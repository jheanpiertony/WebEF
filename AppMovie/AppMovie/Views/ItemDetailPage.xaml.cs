using AppMovie.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMovie.Views
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