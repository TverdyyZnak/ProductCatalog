using Domain.Models;

namespace Application.DTO.ProductDtos
{
    public record ProductDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CaregoryId,
        Category? Category
    );
}
