using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<OrderDTO> GetItem(int id);
        Task<OrderDTO> CreateItem(OrderDTO item);
        Task UpdateItem(OrderDTO item, int id);
        Task DeleteItem(int id);
    }
}
