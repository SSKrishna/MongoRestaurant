using Mongo.Services.ProductAPI.Models.Dto;

namespace Mongo.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int id);    

        Task<ProductDto> CreateUpdateProduct(ProductDto product);

        Task<bool> DeleteProduct(int id);
    }
}
