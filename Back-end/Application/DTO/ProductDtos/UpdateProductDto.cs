using Application.DTO.CategoryDtos;

namespace Application.DTO.ProductDtos
{
    public record UpdateProductDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CategoryId,
        CategoryDto? Category
    );
}
