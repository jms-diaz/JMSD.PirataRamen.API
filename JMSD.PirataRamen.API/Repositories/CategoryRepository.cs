using Dapper;
using JMSD.PirataRamen.API.Context;
using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;

namespace JMSD.PirataRamen.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PirataRamenContext _context;

        public CategoryRepository(PirataRamenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            try
            {
                var sql = "SELECT CategoryId, Name FROM Categories";

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryMultipleAsync(sql);
                    var categories = await result.ReadAsync<Category>();

                    return categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            try
            {
                var sql = @"SELECT CategoryId, Name FROM Categories
                        WHERE CategoryId = @CategoryId";

                using (var connection = _context.CreateConnection())
                {
                    var category = await connection.QuerySingleAsync<Category>(sql, new { CategoryId = id });
                    return category;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            try
            {
                var sql = @"INSERT INTO Categories (Name) 
                    VALUES @Name";

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(sql, category);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            try
            {
                var sql = @"UPDATE Categories SET
                    Name = @Name
                    UpdatedDate = @UpdatedDate";

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(sql, new { Name = category.Name, UpdatedDate = DateTime.Now});
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            try
            {
                var sql = @"DELETE FROM Categories
                        WHERE CategoryId = @CategoryId";

                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync(sql, new { CategoryId = id});
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
