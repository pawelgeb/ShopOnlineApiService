using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly ShopContext context;

        public ProductController (ShopContext shopcontext)
        {
            context = shopcontext;
        }

        [HttpGet]      
        public async Task<ActionResult<List<ProductDTO>>> GetProductDTO()
        {
            return await context.Products
                .Select(x => ProductDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductItemDTO(int id)
        {
            var productItem = await context.Products.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }
            return  ProductDTO(productItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductItem(int id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest();
            }
            var productItem = await context.Products.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }
            productItem.Id = productDTO.Id;
            productItem.Name = productDTO.Name;
            productItem.CategoryId = productDTO.CategoryId;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProductItemExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProductDTO (ProductDTO productDTO)
        {
            var productItem = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                CategoryId = productDTO.CategoryId
            };

            context.Products.Add(productItem);
            await context.SaveChangesAsync();
           
            return CreatedAtAction(
            nameof(GetProductDTO),
            new
            {
             id = productItem.Id
             },
           ProductDTO(productItem));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryItem(int id)
        {
            var productItem = await context.Products.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }
            context.Products.Remove(productItem);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductItemExist(int id)
        {
            return context.Products.Any(e => e.Id == id);
        }
        private static ProductDTO ProductDTO(Product product) => new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId
        };
    }
}
