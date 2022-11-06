using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.Interfaces;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Repositories
{

    public class AdressRepository : IAdressRepository
    {
        private readonly ShopContext _context;
        public AdressRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<AdressDTO> CreateItem(AdressDTO adressDTO)
        {
            var adressItem = new Adress
            {
                Id = adressDTO.Id,
                Street = adressDTO.Street,
                City = adressDTO.City,
                Country = adressDTO.Country,
                HouseNumber = adressDTO.HouseNumber,
                UserId = adressDTO.UserId
            };
            _context.Adresses.Add(adressItem);
            await _context.SaveChangesAsync();
            return adressDTO;
        }
        public async Task DeleteItem(int id)
        {
            var adressItem = await _context.Adresses.FindAsync(id);
            _context.Adresses.Remove(adressItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<AdressDTO>> GetAll()
        {
            var adresses = await _context.Adresses
            .Select(x => AdressDTO(x))
            .ToListAsync();
            return adresses;
        }
        public async Task<AdressDTO> GetItem(int id)
        {
            var adressItem = await _context.Adresses.FindAsync(id);
            return AdressDTO(adressItem);
        }
        public async Task UpdateItem(AdressDTO adressDTO, int id)
        {
            {
                var adress = await _context.Adresses.FindAsync(id);
                adress.Id = adressDTO.Id;
                adress.Street = adressDTO.Street;
                adress.City = adressDTO.City;
                adress.Country = adressDTO.Country;
                adress.HouseNumber = adressDTO.HouseNumber;
                adress.UserId = adressDTO.UserId;
                await _context.SaveChangesAsync();
                }
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
