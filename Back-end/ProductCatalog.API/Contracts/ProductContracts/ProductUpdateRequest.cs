namespace ProductCatalog.API.Contracts.ProductContract
{
    public record ProductUpdateRequest
    (
        string Name,
        string Description,
        decimal Price,
        string MainNote,
        string SubNote,
        Guid CategoryId
    );
}
