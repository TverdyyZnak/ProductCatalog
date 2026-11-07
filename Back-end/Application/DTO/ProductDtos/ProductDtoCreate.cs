
namespace Application.DTO.ProductDtos
{
    public record ProductDtoCreate
    (
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CaregoryId
    );

}
