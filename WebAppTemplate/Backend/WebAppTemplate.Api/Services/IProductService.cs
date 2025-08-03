using WebAppTemplate.Api.Models;
using WebAppTemplate.Api.ViewModels;

namespace WebAppTemplate.Api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel?> GetProductByIdAsync(int id);
        Task<ProductViewModel> CreateProductAsync(CreateProductRequest request);
        Task<ProductViewModel?> UpdateProductAsync(int id, UpdateProductRequest request);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(string category);
    }
}