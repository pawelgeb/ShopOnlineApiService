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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService adressService)
        {
            _productService = adressService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdress()
        {
            return Ok(await _productService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> PostAdress(ProductDTO ProductDTO)
        {
            return Ok(await _productService.CreateItem(ProductDTO));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdress(int id)
        {
            return Ok(await _productService.GetItem(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdress(ProductDTO ProductDTO, int id)
        {
            await _productService.UpdateItem(ProductDTO, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _productService.DeleteItem(id);
            return Ok();
        }
    }
}
