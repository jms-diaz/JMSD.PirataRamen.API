using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;

namespace JMSD.PirataRamen.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetProductsAsync();
                return products;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);
                return product;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
