namespace ProductCatalog.API.Contracts.ProductContract
{
    public record ProductCreateRequest
    (
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CaregoryId
    );
}
