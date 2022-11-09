using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Repositories.Interfaces;

namespace ShopOnlineApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopContext _context;
        public UserRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> CreateItem(UserDTO userDTO)
        {
            var userItem = new User
            {
                Name = userDTO.Name,
                RegisterDate = userDTO.RegisterDate
            };
            _context.Users.Add(userItem);
            await _context.SaveChangesAsync();
            return userDTO;
        }
        public async Task DeleteItem(int id)
        {
            var userItem = await _context.Users.FindAsync(id);
            _context.Users.Remove(userItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var userItem = await _context.Users
            .Select(x => UserDTO(x))
            .ToListAsync();
            return userItem;
        }
        public async Task<UserDTO> GetItem(int id)
        {
            var userItem = await _context.Users.FindAsync(id);
            return UserDTO(userItem);
        }
        public async Task UpdateItem(UserDTO userDTO, int id)
        {

            var userItem = await _context.Users.FindAsync(id);
            userItem.Id = userDTO.Id;
            userItem.Name = userDTO.Name;
            userItem.RegisterDate = userDTO.RegisterDate;
            await _context.SaveChangesAsync();

        }
        private static UserDTO UserDTO(User user) => new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            RegisterDate = user.RegisterDate
        };
    }
}
