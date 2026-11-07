namespace ProductCatalog.API.Contracts.UserContracts
{
    public record UserCreateRequest
    (
        string Login,
        string HashPass,
        bool IsBlocked,
        string UserRole
    );
}
