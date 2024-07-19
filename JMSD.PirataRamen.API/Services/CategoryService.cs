using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;

namespace JMSD.PirataRamen.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            try
            {
                var products = await _categoryRepository.GetAllCategoriesAsync();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }

        public async Task<Category> GetByCategoryIdAsync(int id)
        {
            try
            {
                var product = await _categoryRepository.GetCategoryByIdAsync(id);
                return product;
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
                var result = await _categoryRepository.CreateCategoryAsync(category);
                return result;
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
                var result = await _categoryRepository.CreateCategoryAsync(category);
                return result;
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
                var result = await _categoryRepository.DeleteCategoryAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
