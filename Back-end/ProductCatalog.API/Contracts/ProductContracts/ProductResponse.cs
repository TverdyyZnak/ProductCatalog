using ProductCatalog.API.Contracts.CategoryContracts;

namespace ProductCatalog.API.Contracts.ProductContract
{
    public record ProductResponse
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
