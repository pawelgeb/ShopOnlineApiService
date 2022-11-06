using Microsoft.AspNetCore.Http;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService adressService)
        {
            _categoryService = adressService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdress()
        {
            return Ok(await _categoryService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> PostAdress(CategoryDTO CategoryDTO)
        {
            return Ok(await _categoryService.CreateItem(CategoryDTO));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdress(int id)
        {
            return Ok(await _categoryService.GetItem(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdress(CategoryDTO CategoryDTO, int id)
        {
            await _categoryService.UpdateItem(CategoryDTO, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _categoryService.DeleteItem(id);
            return Ok();
        }
    }
}
