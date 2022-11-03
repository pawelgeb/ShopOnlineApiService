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
    public class CategoriesController : ControllerBase
    {
        private readonly ShopContext context;
        
        public CategoriesController(ShopContext shopContext)
        {
            context = shopContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategory()
        {
            var categories = await context.Categories
            /*return await context.Categories*/
            //.Where(c => c.Id == productId)
            .Select(x => CategoryDTO(x))
            .ToListAsync();
            return categories;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryDTO(int id)
        {
            var categoryItem = await context.Categories.FindAsync(id);
            if (categoryItem == null)
            {
                return NotFound();
            }
            return CategoryDTO(categoryItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoriesItem(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return BadRequest();
            }
            var categoryItem = await context.Categories.FindAsync(id);
            if (categoryItem == null)
            {
                return NotFound();
            }
            categoryItem.Name = categoryDTO.Name;
            categoryItem.AddData = categoryDTO.AddData;
            categoryItem.Empty = categoryItem.Empty;
            categoryItem.Id = categoryItem.Id;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CategoryItemExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategoryItem (CategoryDTO categoryDTO)
        {
            var categoryItem = new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                AddData = categoryDTO.AddData,
                Empty = categoryDTO.Empty,

            };
            context.Categories.Add(categoryItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCategoryDTO),
                new
                {
                    id = categoryDTO.Id
                },
                CategoryDTO(categoryItem));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryItem(int id)
        {
            var categoryItem = await context.Categories.FindAsync(id);
            if (categoryItem == null)
            {
                return NotFound();
            }
            context.Categories.Remove(categoryItem);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool CategoryItemExist(int id)
        {
            return context.Categories.Any(e => e.Id == id);
        }

        private static CategoryDTO CategoryDTO(Category category) => new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
            AddData = category.AddData,
            Empty = category.Empty
        };
    }
}
