using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<OrderDTO> GetItem(int id);
        Task<OrderDTO> CreateItem(OrderDTO item);
        Task UpdateItem(OrderDTO adress, int id);
        Task DeleteItem(int id);
    }
}
