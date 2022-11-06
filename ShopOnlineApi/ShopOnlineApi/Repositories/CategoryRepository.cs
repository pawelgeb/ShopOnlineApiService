using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Repositories.Interfaces;

namespace ShopOnlineApi.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<CategoryDTO> CreateItem(CategoryDTO categoryDTO)
        {
            var categoryItem = new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                AddData = categoryDTO.AddData,
                Empty = categoryDTO.Empty
            };
            _context.Categories.Add(categoryItem);
            await _context.SaveChangesAsync();
            return categoryDTO;
        }
        public async Task DeleteItem(int id)
        {
            var categoryItem = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoryItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categoryItem = await _context.Categories
            .Select(x => CategoryDTO(x))
            .ToListAsync();
            return categoryItem;
        }
        public async Task<CategoryDTO> GetItem(int id)
        {
            var categoryItem = await _context.Categories.FindAsync(id);
            return CategoryDTO(categoryItem);
        }
        public async Task UpdateItem(CategoryDTO categoryDTO, int id)
        {
            {
                var category = await _context.Categories.FindAsync(id);
                category.Id = categoryDTO.Id;
                category.Name = categoryDTO.Name;
                category.AddData = categoryDTO.AddData;
                category.Empty = categoryDTO.Empty;
                await _context.SaveChangesAsync();
            }
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
