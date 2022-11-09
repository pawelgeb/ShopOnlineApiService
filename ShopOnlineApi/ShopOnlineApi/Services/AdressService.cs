using ShopOnlineApi.Interfaces;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Services
{
    public class AdressService : IAdressService
    {
        private readonly IAdressRepository _adressRepo;
        public AdressService(IAdressRepository adressRepo)
        {
            _adressRepo = adressRepo;
        }
        public Task<AdressDTO> CreateItem(AdressDTO item)
        {
            return _adressRepo.CreateItem(item);
        }
        public Task DeleteItem(int id)
        {
            return _adressRepo.DeleteItem(id);
            //todo: if null to co dalej? sol: return null;
        }
        public Task<IEnumerable<AdressDTO>> GetAll()
        {
            return _adressRepo.GetAll();
        }
        public Task<AdressDTO> GetItem(int id)
        {
            return _adressRepo.GetItem(id);
        }
        public Task UpdateItem(AdressDTO adress, int T2)
        {
            return _adressRepo.UpdateItem(adress, T2);
        }
    }
}
