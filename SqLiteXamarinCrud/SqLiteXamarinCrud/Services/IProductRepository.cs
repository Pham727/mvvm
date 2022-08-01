using SqLiteXamarinCrud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqLiteXamarinCrud.Services
{
    public interface IProductRepository
    {
        Task<bool> AddProductAsync(ProductInfo productInfo);
        Task<bool> UpdateProductAsync(ProductInfo productInfo);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductInfo> GetProductAsync(int id);
        Task<IEnumerable<ProductInfo>> GetProductsAsync();
    }
}
