using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetItem(int id);
        Task<ProductDTO> CreateItem(ProductDTO item);
        Task UpdateItem(ProductDTO item, int id);
        Task DeleteItem(int id);
    }
}
