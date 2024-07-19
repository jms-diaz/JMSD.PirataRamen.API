using Dapper;
using JMSD.PirataRamen.API.Context;
using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;

namespace JMSD.PirataRamen.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PirataRamenContext _context;

        public ProductRepository(PirataRamenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var sql = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.ImageUrl, c.CategoryId, c.Name AS Category
                    FROM Products p
                    LEFT JOIN Categories c
                    ON c.CategoryId = p.CategoryId
                ";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryMultipleAsync(sql);
                var products = await result.ReadAsync<Product>();

                return products.ToList();
            }

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var sql = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.ImageUrl, c.CategoryId, c.Name AS Category
                            FROM Products p
                            LEFT JOIN Categories c 
                            ON c.CategoryId = p.CategoryId
                            WHERE ProductId = @ProductId
                        ";

            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleAsync<Product>(sql, new {ProductId = id });
                return product;
            }
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            var sql = @"INSERT INTO Products (Name, Description, Price, ImageUrl, CategoryId)
                VALUES (@Name, @Description, @Price, @ImageUrl, @CategoryId)
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, product);
                return result;
            }
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var sql = @"UPDATE Products SET 
                Name = @Name,
                Description = @Description,
                Price = @Price,
                ImageUrl = @ImageUrl,
                CategoryId = @CategoryId
                WHERE ProductId = @ProductId
            ";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, product);
                return result;
            }
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var sql = @"DELETE FROM Products
                WHERE ProductId = @ProductId";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, new {ProductId = id});
                return result;
            }
        }
    }
}
