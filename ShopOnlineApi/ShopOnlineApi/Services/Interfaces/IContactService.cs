using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAll();
        Task<ContactDTO> GetItem(int id);
        Task<ContactDTO> CreateItem(ContactDTO item);
        Task UpdateItem(ContactDTO item, int id);
        Task DeleteItem(int id);
    }
}
