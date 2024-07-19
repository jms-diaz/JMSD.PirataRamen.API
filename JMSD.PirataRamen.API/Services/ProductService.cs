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

        public async Task<int> CreateProductAsync(Product product)
        {
            try
            {
                var result = await _productRepository.CreateProductAsync(product);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            try
            {
                var result = await _productRepository.UpdateProductAsync(product);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            try
            {
                var result = await _productRepository.DeleteProductAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
