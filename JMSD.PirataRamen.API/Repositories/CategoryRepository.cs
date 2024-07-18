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
                var sql = "SELECT CategoryId, Name FROM Category";

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
                var sql = @"SELECT CategoryId, Name FROM CATEGORY
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

        public Task<Category> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
