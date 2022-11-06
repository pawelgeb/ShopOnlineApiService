using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Repositories.Interfaces;

namespace ShopOnlineApi.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductDTO> CreateItem(ProductDTO productDTO)
        {
            var productItem = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                CategoryId = productDTO.CategoryId
            };
            _context.Products.Add(productItem);
            await _context.SaveChangesAsync();
            return productDTO;
        }
        public async Task DeleteItem(int id)
        {
            var productItem = await _context.Products.FindAsync(id);
            _context.Products.Remove(productItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var productItem = await _context.Products
            .Select(x => ProductDTO(x))
            .ToListAsync();
            return productItem;
        }
        public async Task<ProductDTO> GetItem(int id)
        {
            var productItem = await _context.Products.FindAsync(id);
            return ProductDTO(productItem);
        }
        public async Task UpdateItem(ProductDTO productDTO, int id)
        {
            {
                var productItem = await _context.Products.FindAsync(id);
                productItem.Id = productDTO.Id;
                productItem.Name = productDTO.Name;
                productItem.CategoryId = productDTO.CategoryId;
                await _context.SaveChangesAsync();
            }
        }
        private static ProductDTO ProductDTO(Product product) => new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId
        };
    }
}
