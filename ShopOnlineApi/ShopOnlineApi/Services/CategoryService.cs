using ShopOnlineApi.Interfaces;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Repositories.Interfaces;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public Task<CategoryDTO> CreateItem(CategoryDTO item)
        {
            return _categoryRepo.CreateItem(item);
        }
        public Task DeleteItem(int id)
        {
            return _categoryRepo.DeleteItem(id);
        }
        public Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _categoryRepo.GetAll();
        }
        public Task<CategoryDTO> GetItem(int id)
        {
            return _categoryRepo.GetItem(id);
        }
        public Task UpdateItem(CategoryDTO category, int T2)
        {
            return _categoryRepo.UpdateItem(category, T2);
        }
    }
}
