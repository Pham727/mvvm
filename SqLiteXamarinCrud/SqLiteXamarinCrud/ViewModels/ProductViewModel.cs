using SqLiteXamarinCrud.Models;
using SqLiteXamarinCrud.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqLiteXamarinCrud.ViewModels
{
    public class ProductViewModel : BaseProductViewModel
    {
        public Command LoadProductCommand { get; }
        public ObservableCollection<ProductInfo> ProductInfos { get; }

        public Command AddProductCommand { get; }
        public Command ProdutTappedEdit { get; }
        public Command ProdutTappedDeleted { get; }
        public ProductViewModel(INavigation _navigation)
        {
            LoadProductCommand = new Command(async () => await ExecuteLoadProductCommand());
            ProductInfos = new ObservableCollection<ProductInfo>();
            AddProductCommand = new Command(OnAddProduct);
            ProdutTappedEdit = new Command<ProductInfo>(OnEditProduct);
            ProdutTappedDeleted = new Command<ProductInfo>(OnDeleteProduct);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
        async Task ExecuteLoadProductCommand()
        {
            IsBusy = true;
            try
            {
                ProductInfos.Clear();
                var prodList = await App.ProductService.GetProductsAsync();
                foreach (var prod in prodList)
                {
                    ProductInfos.Add(prod);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddProduct()
        {
            await Shell.Current.GoToAsync(nameof(AddProductPage));
        }
        private async void OnEditProduct( ProductInfo prod)
        {
            await Navigation.PushAsync(new AddProductPage(prod));
        }

        private async void OnDeleteProduct(ProductInfo prod)
        {
            if(prod == null)
            {
                return;
            }
            await App.ProductService.DeleteProductAsync(prod.ProductId);
            await ExecuteLoadProductCommand();
        }
    }
}
