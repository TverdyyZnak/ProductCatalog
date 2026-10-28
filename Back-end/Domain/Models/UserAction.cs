using Domain.Interfaces;
using Domain.Primitives;

namespace Domain.Models
{
    public class UserAction: IEntity
    {
        public Guid Id { get; }
        public string Text { get; } = string.Empty;
        public DateTime ActionDate { get; }
        public User? UserActor { get; }

        private UserAction(Guid id, string text, DateTime actionDate, User? user)
        {
            Id = id;
            Text = text;
            ActionDate = actionDate;
            UserActor = user;
        }

        public static Result<UserAction> Create(Guid id, string text, DateTime actionDate, User user)
        {
            var errors = new List<string>();

            if (user == null)
            {
                errors.Add("Пользователь не указан");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                errors.Add("Текст действия не указан");
            }

            if (errors.Any()) 
            {
                return Result<UserAction>.Fail(errors);
            }

            return Result<UserAction>.Success(new UserAction(id, text, actionDate, user));
        }


    }
}
