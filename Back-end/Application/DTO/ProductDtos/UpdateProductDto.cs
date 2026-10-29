using Application.DTO.CategoryDtos;

namespace Application.DTO.ProductDtos
{
    public record UpdateProductDto(
        Guid id,
        string name,
        string description,
        decimal price,
        string mainNote,
        string subNote,
        CategoryDto category
    );
}
