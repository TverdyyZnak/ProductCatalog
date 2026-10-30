namespace Infrastructure.DB.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
        public string Role { get; set; } = "User";
    }
}
