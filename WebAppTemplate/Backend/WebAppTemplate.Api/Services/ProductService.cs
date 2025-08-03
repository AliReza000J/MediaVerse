using WebAppTemplate.Api.Models;
using WebAppTemplate.Api.ViewModels;

namespace WebAppTemplate.Api.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, StockQuantity = 10, Category = "Electronics", CreatedAt = DateTime.UtcNow.AddDays(-20), IsActive = true },
            new Product { Id = 2, Name = "Coffee Mug", Description = "Ceramic coffee mug", Price = 12.99m, StockQuantity = 50, Category = "Kitchen", CreatedAt = DateTime.UtcNow.AddDays(-10), IsActive = true },
            new Product { Id = 3, Name = "Wireless Mouse", Description = "Bluetooth wireless mouse", Price = 29.99m, StockQuantity = 0, Category = "Electronics", CreatedAt = DateTime.UtcNow.AddDays(-5), IsActive = true },
            new Product { Id = 4, Name = "Notebook", Description = "Spiral-bound notebook", Price = 5.99m, StockQuantity = 100, Category = "Office", CreatedAt = DateTime.UtcNow.AddDays(-2), IsActive = true }
        };

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            await Task.Delay(10); // Simulate async operation
            return _products.Where(p => p.IsActive).Select(MapToViewModel);
        }

        public async Task<ProductViewModel?> GetProductByIdAsync(int id)
        {
            await Task.Delay(10); // Simulate async operation
            var product = _products.FirstOrDefault(p => p.Id == id && p.IsActive);
            return product != null ? MapToViewModel(product) : null;
        }

        public async Task<ProductViewModel> CreateProductAsync(CreateProductRequest request)
        {
            await Task.Delay(10); // Simulate async operation
            
            var product = new Product
            {
                Id = _products.Max(p => p.Id) + 1,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                Category = request.Category,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _products.Add(product);
            return MapToViewModel(product);
        }

        public async Task<ProductViewModel?> UpdateProductAsync(int id, UpdateProductRequest request)
        {
            await Task.Delay(10); // Simulate async operation
            
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;
            product.Category = request.Category;
            product.IsActive = request.IsActive;
            product.UpdatedAt = DateTime.UtcNow;

            return MapToViewModel(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            await Task.Delay(10); // Simulate async operation
            
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.IsActive = false; // Soft delete
            product.UpdatedAt = DateTime.UtcNow;
            return true;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(string category)
        {
            await Task.Delay(10); // Simulate async operation
            return _products
                .Where(p => p.IsActive && p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Select(MapToViewModel);
        }

        private static ProductViewModel MapToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
                CreatedAt = product.CreatedAt,
                IsActive = product.IsActive
            };
        }
    }
}