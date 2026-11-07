using Application.DTO.ProductDtos;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<List<ProductDto>> GetProductByFilter(ProductFiltre filtre);
        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<Guid> CreateProductAsync(ProductDtoCreate productDto);
        Task<Guid> UpdateProductAsync(Guid id, ProductDtoUpdate productDto);
        Task<Guid> DeleteProductAsync(Guid id);
    }
}
