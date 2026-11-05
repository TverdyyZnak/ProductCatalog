namespace Application.DTO.ProductDtos
{
    public record ProductFiltre
    (
        string? SearchName,
        decimal? MinPrice,
        decimal? MaxPrice,
        Guid? CategoryId, 
        string? SortBy
    );
}
