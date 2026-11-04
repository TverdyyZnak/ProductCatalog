namespace Application.DTO.ProductDtos
{
    public record ProductDto
    (
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CaregoryId,
        string CategoryName
    );
}
