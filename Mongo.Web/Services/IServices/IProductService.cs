using Mongo.Web.Models;

namespace Mongo.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();

        Task<T> GetProductsByIdAsync<T>(int productId);

        Task<T> CreateProductAsync<T>(ProductDto product);

        Task<T> UpdateProductAsync<T>(ProductDto product);

        Task<T> DeleteProductAsync<T>(int productId);
    }
}
