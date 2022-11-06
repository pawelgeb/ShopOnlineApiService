using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Repositories.Interfaces;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public Task<UserDTO> CreateItem(UserDTO item)
        {
            return _userRepo.CreateItem(item);
        }
        public Task DeleteItem(int id)
        {
            return _userRepo.DeleteItem(id);
        }
        public Task<IEnumerable<UserDTO>> GetAll()
        {
            return _userRepo.GetAll();
        }
        public Task<UserDTO> GetItem(int id)
        {
            return _userRepo.GetItem(id);
        }
        public Task UpdateItem(UserDTO user, int T2)
        {
            return _userRepo.UpdateItem(user, T2);
        }
    }
}
