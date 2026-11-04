using Application.DTO.ProductDtos;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<List<ProductDto>> GetProductsByNameAsync(string name);
        Task<List<ProductDto>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice);
        Task<List<ProductDto>> GetProductsByPriceAsync(decimal Price);
        Task<Guid> CreateProductAsync(ProductDtoCreate productDto);
        Task<Guid> UpdateProductAsync(Guid id, ProductDtoUpdate productDto);
        Task<Guid> DeleteProductAsync(Guid id);
    }
}
