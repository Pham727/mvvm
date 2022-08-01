using SqLiteXamarinCrud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqLiteXamarinCrud.ViewModels
{
    public class AddProductViewModel:BaseProductViewModel
    {
        public Command SaveCommand { get; }
        public Command CancleCommand { get; }
        
        public AddProductViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancleCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            ProductInfo = new ProductInfo();
        }
        public async void OnSave()
        {
            var product =ProductInfo;
            await App.ProductService.AddProductAsync(product);
            await Shell.Current.GoToAsync("..");
        }

        public async void OnCancel()
        {
            //var product = ProductInfo;
           // await App.ProductService.DeleteProductAsync(product.ProductId);
            await Shell.Current.GoToAsync("..");
        }
    }
}
