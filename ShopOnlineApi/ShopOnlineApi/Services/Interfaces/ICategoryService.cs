using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetItem(int id);
        Task<CategoryDTO> CreateItem(CategoryDTO item);
        Task UpdateItem(CategoryDTO item, int id);
        Task DeleteItem(int id);
    }
}
