using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShopContext context;
        public UsersController(ShopContext shopContext)
        {
            this.context = shopContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            return await context.Users
                .Select(x => UserDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserDTO(int id)
        {
            var userItem = await context.Users.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }
            return UserDTO(userItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserItem(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }
            var userItem = await context.Users.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }
            userItem.Name = userDTO.Name;
            userItem.RegisterDate = userDTO.RegisterDate;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UserItemExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUserItem(UserDTO userDTO)
        {
            var userItem = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                RegisterDate = userDTO.RegisterDate
            };
            context.Users.Add(userItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUserDTO),
                new
                {
                    id = userItem.Id
                },
                UserDTO(userItem));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserItem(int id)
        {
            var userItem = await context.Users.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }
            context.Users.Remove(userItem);
            await context.SaveChangesAsync();
            return NoContent();
        }
        private bool UserItemExist(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }
        private static UserDTO UserDTO(User user) => new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            RegisterDate = user.RegisterDate
        };
    }
}
