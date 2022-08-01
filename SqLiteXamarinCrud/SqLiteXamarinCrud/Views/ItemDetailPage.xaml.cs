using SqLiteXamarinCrud.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SqLiteXamarinCrud.Views
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