using JMSD.PirataRamen.API.Models;

namespace JMSD.PirataRamen.API.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetByCategoryIdAsync(int id);
        Task<int> CreateCategoryAsync(Category category);
        Task<int> UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int id);
    }
}
