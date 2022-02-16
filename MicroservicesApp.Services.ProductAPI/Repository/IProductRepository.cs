using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesApp.Services.ProductAPI.Models.DTO;

namespace MicroservicesApp.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
