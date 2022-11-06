using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetItem(int id);
        Task<UserDTO> CreateItem(UserDTO item);
        Task UpdateItem(UserDTO item, int id);
        Task DeleteItem(int id);
    }
}
