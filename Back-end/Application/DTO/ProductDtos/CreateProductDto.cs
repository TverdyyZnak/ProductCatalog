using Application.DTO.CategoryDtos;

namespace Application.DTO.ProductDtos
{
    public record CreateProductDto(
        string name,
        string description,
        decimal price,
        string mainNote,
        string subNote,
        CategoryDto category
    );
}
