using Domain.Models;

namespace Application.DTO.ProductDtos
{
    public record ProductDto(
        Guid id,
        string name,
        string description,
        decimal price,
        string mainNote,
        string subNote,
        Category Category
    );
}
