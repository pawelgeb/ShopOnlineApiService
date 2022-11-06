using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactDTO>> GetAll();
        Task<ContactDTO> GetItem(int id);
        Task<ContactDTO> CreateItem(ContactDTO item);
        Task UpdateItem(ContactDTO item, int id);
        Task DeleteItem(int id);
    }
}
