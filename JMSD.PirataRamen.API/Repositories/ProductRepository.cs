using Dapper;
using JMSD.PirataRamen.API.Context;
using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;

namespace JMSD.PirataRamen.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //private readonly ILogger _logger;
        private readonly PirataRamenContext _context;

        public ProductRepository(PirataRamenContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var sql = @"SELECT ProductId, Name, Description, Price, ImageUrl
                    FROM Product";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryMultipleAsync(sql);
                var products = await result.ReadAsync<Product>();

                return products.ToList();
            }

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var sql = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.ImageUrl, c.Name AS Category
                            FROM Product p
                            LEFT JOIN Category c 
                            ON c.CategoryId = p.CategoryId
                            WHERE ProductId = @ProductId
                        ";

            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleAsync<Product>(sql, new {ProductId = id });
                return product;
            }
        }

        public Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
