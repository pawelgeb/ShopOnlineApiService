using ShopOnlineApi.ModelsDTO;

namespace ShopOnlineApi.Services.Interfaces
{
    public interface IAdressService
    {
        Task<IEnumerable<AdressDTO>> GetAll();
        Task<AdressDTO> GetItem(int id);
        Task<AdressDTO> CreateItem(AdressDTO item);
        Task UpdateItem(AdressDTO adress, int T2);
        Task DeleteItem(int id);
    }
}
