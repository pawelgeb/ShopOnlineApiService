using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdress()
        {
            return Ok(await _userService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> PostAdress(UserDTO UserDTO)
        {
            return Ok(await _userService.CreateItem(UserDTO));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdress(int id)
        {
            return Ok(await _userService.GetItem(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdress(UserDTO UserDTO, int id)
        {
            await _userService.UpdateItem(UserDTO, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _userService.DeleteItem(id);
            return Ok();
        }
    }
}
