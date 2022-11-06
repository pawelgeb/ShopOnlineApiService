using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetItem(int id);
        Task<UserDTO> CreateItem(UserDTO item);
        Task UpdateItem(UserDTO adress, int T2);
        Task DeleteItem(int id);
    }
}
