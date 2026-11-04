namespace Application.DTO.ProductDtos
{
    public record ProductDtoUpdate
    (
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CaregoryId
    );
}
