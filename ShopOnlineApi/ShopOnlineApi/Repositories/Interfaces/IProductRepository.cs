using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetItem(int id);
        Task<ProductDTO> CreateItem(ProductDTO item);
        Task UpdateItem(ProductDTO item, int id);
        Task DeleteItem(int id);
    }
}
