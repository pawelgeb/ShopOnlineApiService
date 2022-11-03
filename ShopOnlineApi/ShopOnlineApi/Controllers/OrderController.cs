using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ShopContext context;
        public OrderController(ShopContext shopcontext)
        {
            context = shopcontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrderDTO() 
        {
            return await context.Orders
                .Select(x => OrderDTO(x))
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetItemOrderDTO(int id)
        {
            var orderItem = await context.Orders.FindAsync(id);
            if (orderItem == null )
            {
                return NotFound();
            }
            return OrderDTO(orderItem);
        }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(OrderDTO orderDTO)
        {
            var orderItem = new Order
            {
                Id = orderDTO.Id,
                ProductId = orderDTO.ProductId,
                Price = orderDTO.Price,
                OrderDate = orderDTO.OrderDate,
                UserId = orderDTO.UserId
            };

            context.Orders.Add(orderItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOrderDTO),
                new
                {
                    id = orderItem.Id
                },
                OrderDTO(orderItem));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderDTO orderDTO)
        {
            if (id != orderDTO.Id)
            {
                return BadRequest();
            }
            var orderItem = await context.Orders.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            orderItem.Id = orderDTO.Id;
            orderItem.OrderDate = orderDTO.OrderDate;
            orderItem.Price = orderDTO.Price;
            orderItem.ProductId = orderDTO.ProductId;
            orderItem.UserId = orderDTO.UserId;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!OrdersItemExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await context.Orders.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            context.Orders.Remove(orderItem);
            await context.SaveChangesAsync();
            return NoContent();
        }
        private bool OrdersItemExist(int id)
        {
            return context.Orders.Any(e => e.Id == id);
        }


        private static OrderDTO OrderDTO(Order order) => new OrderDTO
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Price = order.Price,
            ProductId = order.ProductId,
            UserId = order.UserId
        };
     }
}
