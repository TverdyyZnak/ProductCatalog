namespace ProductCatalog.API.Contracts.ProductContracts
{
    public record ProductFiltreRequest
    (
        string? SearchName,
        decimal? MinPrice,
        decimal? MaxPrice,
        Guid? CategoryId, 
        string? SortBy
    );
}
