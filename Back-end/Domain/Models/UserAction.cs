using Domain.Primitives;
using Domain.Primitives.Interfaces;

namespace Domain.Models
{
    public class UserAction : IEntity
    {
        public Guid Id { get; }
        public string Text { get; } = string.Empty;
        public DateTime ActionDate { get; }
        public Guid UserActorId { get; }

        private UserAction(Guid id, string text, DateTime actionDate, Guid userId)
        {
            Id = id;
            Text = text;
            ActionDate = actionDate;
            UserActorId = userId;
        }

        public static Result<UserAction> Create(Guid id, string text, DateTime actionDate, Guid userId)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(text))
            {
                errors.Add("Текст действия не указан");
            }

            if (errors.Any()) 
            {
                return Result<UserAction>.Fail(errors);
            }

            return Result<UserAction>.Success(new UserAction(id, text, actionDate, userId));
        }


    }
}
