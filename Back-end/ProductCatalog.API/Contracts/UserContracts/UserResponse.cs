namespace ProductCatalog.API.Contracts.UserContracts
{
    public record UserResponse
    (
        Guid Id,
        string Login,
        string HashPass,
        bool IsBlocked,
        string UserRole
    );
    
}
