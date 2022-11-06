using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Repositories.Interfaces;

namespace ShopOnlineApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopContext _context;
        public OrderRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<OrderDTO> CreateItem(OrderDTO orderDTO)
        {
            var orderItem = new Order
            {
                Id = orderDTO.Id,
                UserId = orderDTO.UserId,
                OrderDate = orderDTO.OrderDate,
                Price = orderDTO.Price,
                ProductId = orderDTO.ProductId
            };
            _context.Orders.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderDTO;
        }
        public async Task DeleteItem(int id)
        {
            var orderItem = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orderItem = await _context.Orders
            .Select(x => OrderDTO(x))
            .ToListAsync();
            return orderItem;
        }
        public async Task<OrderDTO> GetItem(int id)
        {
            var orderItem = await _context.Orders.FindAsync(id);
            return OrderDTO(orderItem);
        }
        public async Task UpdateItem(OrderDTO orderDTO, int id)
        {
            {
                var orderItem = await _context.Orders.FindAsync(id);
                orderItem.Id = orderDTO.Id;
                orderItem.UserId = orderDTO.UserId;
                orderItem.OrderDate = orderDTO.OrderDate;
                orderItem.Price = orderDTO.Price;
                orderItem.ProductId = orderDTO.ProductId;
                await _context.SaveChangesAsync();
            }
        }
        private static OrderDTO OrderDTO(Order order) => new OrderDTO
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            Price = order.Price,
            ProductId = order.ProductId
        };
    }
}
