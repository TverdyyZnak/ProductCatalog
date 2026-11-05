namespace Application.Commons
{
    public class UserAction
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Text { get; } = string.Empty;
        public DateTime ActionDateTime { get; }
        public ActionType ActionType { get; }

        public UserAction(Guid id, Guid userId, string text, DateTime dateTime, ActionType type)
        {
            Id = id;
            UserId = userId;
            Text = text;
            ActionDateTime = dateTime;
            ActionType = type;
        }
    }
}
