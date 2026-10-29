using Application.DTO.CategoryDtos;
using Application.DTO.ProductDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<Result<List<ProductDto>>> GetAllProductsAsync();
        Task<Result<List<ProductDto>>> GetProductsByCategoryAsync(CategoryDto category);
        Task<Result<ProductDto>> GetProductByIdAsync(Guid id);
        Task<Result<List<ProductDto>>> GetProductsByNameAsync(string name);
        Task<Result<List<ProductDto>>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice);
        Task<Result<Guid>> CreateProductAsync(CreateProductDto product);
        Task<Result<Guid>> UpdateProductAsync(UpdateProductDto product);
        Task<Result<Guid>> DeleteProductAsync(Guid id);
    }
}
