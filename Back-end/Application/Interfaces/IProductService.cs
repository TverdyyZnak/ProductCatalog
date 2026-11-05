using Application.DTO.ProductDtos;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<ProductDto> GetProductByFilter();
        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<Guid> CreateProductAsync(ProductDtoCreate productDto);
        Task<Guid> UpdateProductAsync(Guid id, ProductDtoUpdate productDto);
        Task<Guid> DeleteProductAsync(Guid id);
    }
}
