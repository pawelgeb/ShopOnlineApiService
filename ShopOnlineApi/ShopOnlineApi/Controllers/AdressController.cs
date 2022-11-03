using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly ShopContext context;
        public AdressController(ShopContext shopContext)
        {
            this.context = shopContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<AdressDTO>>> Get()
        {
            return await context.Adresses
                .Select(x => AdressDTO(x))
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AdressDTO>> GetAdressDTO(int id)
        {
            var adressItem = await context.Adresses.FindAsync(id);
            if (adressItem == null)
            {
                return NotFound();
            }
            return AdressDTO(adressItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdressItem(int id, AdressDTO adressDTO)
        {
            if (id != adressDTO.UserId)
            {
                return BadRequest();
            }
            var adress = await context.Adresses.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }
            adress.Id = adressDTO.Id;
            adress.Street = adressDTO.Street;
            adress.City = adressDTO.City;
            adress.Country = adressDTO.Country;
            adress.HouseNumber = adressDTO.HouseNumber;
            adress.UserId = adressDTO.UserId;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AdressItemExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AdressDTO>> CreateAdressItem(AdressDTO adressDTO)
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
            context.Adresses.Add(adressItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAdressDTO),
                new { id = adressItem.Id },
                AdressDTO(adressItem));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdressItem(int id)
        {
            var adressItem = await context.Adresses.FindAsync(id);
            if (adressItem == null)
            {
                return NotFound();
            }
            context.Adresses.Remove(adressItem);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool AdressItemExist(int id)
        {
            return context.Users.Any(e => e.Id == id);
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


