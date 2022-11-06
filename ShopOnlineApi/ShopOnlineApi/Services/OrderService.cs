using ShopOnlineApi.Interfaces;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Repositories.Interfaces;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Task<OrderDTO> CreateItem(OrderDTO item)
        {
            return _orderRepo.CreateItem(item);
        }
        public Task DeleteItem(int id)
        {
            return _orderRepo.DeleteItem(id);
        }
        public Task<IEnumerable<OrderDTO>> GetAll()
        {
            return _orderRepo.GetAll();
        }
        public Task<OrderDTO> GetItem(int id)
        {
            return _orderRepo.GetItem(id);
        }
        public Task UpdateItem(OrderDTO order, int T2)
        {
            return _orderRepo.UpdateItem(order, T2);
        }
    }
}
