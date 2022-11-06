using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Repositories.Interfaces;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Services
{
    public class ContactService:IContactService
    {
        private readonly IContactRepository _contactRepo;
        public ContactService(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }
        public Task<ContactDTO> CreateItem(ContactDTO item)
        {
            return _contactRepo.CreateItem(item);
        }
        public Task DeleteItem(int id)
        {
            return _contactRepo.DeleteItem(id);
        }
        public Task<IEnumerable<ContactDTO>> GetAll()
        {
            return _contactRepo.GetAll();
        }
        public Task<ContactDTO> GetItem(int id)
        {
            return _contactRepo.GetItem(id);
        }
        public Task UpdateItem(ContactDTO adress, int T2)
        {
            return _contactRepo.UpdateItem(adress, T2);
        }
    }
}
