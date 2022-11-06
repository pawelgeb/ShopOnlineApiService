using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.Repositories.Interfaces;
using ShopOnlineApi.Services.Interfaces;

namespace ShopOnlineApi.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepo;
        public ProductService(IProductRepository adressRepo)
        {
            _productRepo = adressRepo;
        }
        public Task<ProductDTO> CreateItem(ProductDTO item)
        {
            return _productRepo.CreateItem(item);
        }
        public Task DeleteItem(int id)
        {
            return _productRepo.DeleteItem(id);
        }
        public Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _productRepo.GetAll();
        }
        public Task<ProductDTO> GetItem(int id)
        {
            return _productRepo.GetItem(id);
        }
        public Task UpdateItem(ProductDTO product, int T2)
        {
            return _productRepo.UpdateItem(product, T2);
        }
    }
}
