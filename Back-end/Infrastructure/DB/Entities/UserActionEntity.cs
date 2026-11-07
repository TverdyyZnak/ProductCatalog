using Application.Commons;

namespace Infrastructure.DB.Entities
{
    public class UserActionEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime ActionDateTime { get; set; }
        public ActionType ActionType { get; set; }
    }
}
