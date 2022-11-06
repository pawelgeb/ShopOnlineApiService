using Microsoft.AspNetCore.Mvc;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Interfaces
{
    public interface IAdressRepository
    {
        Task<IEnumerable<AdressDTO>> GetAll();
        Task<AdressDTO> GetItem(int id);
        Task<AdressDTO> CreateItem(AdressDTO item);
        Task UpdateItem(AdressDTO adress, int T2);
        Task DeleteItem(int id);
    }
}
