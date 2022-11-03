using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Repository
{

    public interface IAdressRepository
    {
        Task<ActionResult<List<AdressDTO>>> GetDTO();
        Task<ActionResult<AdressDTO>> GetItemDTO(int id);
        void DeleteItemDTO(int id);

    }
    public class AddressRepository : IAdressRepository
    {
        readonly ShopContext _context;
        public AddressRepository()
        {

        }

        public AddressRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<AdressDTO>>> GetDTO()
        {
            return await _context.Adresses
                .Select(p => AdressDTO(p))
                .ToListAsync();
        }
        public async Task<ActionResult<AdressDTO>> GetItemDTO(int id)
        {
            var adressItem = await _context.Adresses.FindAsync(id);
            return AdressDTO(adressItem);
        }

        public async void DeleteItemDTO(int id)
        {
            var adressItem = await _context.Adresses.FindAsync(id);
            _context.Adresses.Remove(adressItem);
            await _context.SaveChangesAsync();
        }

        private static AdressDTO AdressDTO(Adress adress) => new AdressDTO
        {
            Id = adress.Id,
            Street = adress.Street,
            City = adress.City,
            Country = adress.Country,
            HouseNumber = adress.HouseNumber,
            UserId = adress.UserId
        };
    }
}
