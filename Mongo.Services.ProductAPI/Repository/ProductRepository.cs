using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.ProductAPI.DbContexts;
using Mongo.Services.ProductAPI.Models;
using Mongo.Services.ProductAPI.Models.Dto;

namespace Mongo.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto product)
        {
            Product product1 = _mapper.Map<Product>(product);
            if (product1.ProductId > 0)
            {
                _db.Products.Update(product1);
            }
            else
            {
                _db.Products.Add(product1);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product1);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(a => a.ProductId == id);
                if (product == null) { return false; }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product product = await _db.Products.Where(x=>x.ProductId==id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}
