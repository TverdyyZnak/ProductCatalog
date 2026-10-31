using Domain.Models;

namespace Infrastructure.DB.Entities
{
    public class UserActionEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? UserActor { get; set; }

    }
}
