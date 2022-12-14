using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdressesController : ControllerBase
    {
        private readonly IAdressService _adressService;
        public AdressesController(IAdressService adressService)
        {
            _adressService = adressService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdress()
        {
            return Ok(await _adressService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> PostAdress(AdressDTO adressDTO)
        {
            return Ok(await _adressService.CreateItem(adressDTO));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdress(int id)
        {
            return Ok(await _adressService.GetItem(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdress(AdressDTO adressDTO, int id)
        {
            await _adressService.UpdateItem(adressDTO, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _adressService.DeleteItem(id);
            //todo: if null return 404 Not Found
            return Ok();
        }
    }
}


