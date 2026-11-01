using Application.DTO.CategoryDtos;
using Application.DTO.ProductDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<List<ProductDto>> GetProductsByCategoryAsync(CategoryDto category);
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<List<ProductDto>> GetProductsByNameAsync(string name);
        Task<List<ProductDto>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice);
        Task<Guid> CreateProductAsync(CreateProductDto product);
        Task<Guid> UpdateProductAsync(UpdateProductDto product);
        Task<Guid> DeleteProductAsync(Guid id);
    }
}
