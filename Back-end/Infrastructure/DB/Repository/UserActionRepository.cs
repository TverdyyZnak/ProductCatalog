using Application.Commons;
using Application.Interfaces;
using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Repository
{
    internal class UserActionRepository : IUserActionRepository
    {
        private readonly AppDBContext _context;

        public UserActionRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task CreateActionAsync(UserAction action)
        {
            UserActionEntity entity = new UserActionEntity
            {
                Id = action.Id,
                UserId = action.UserId,
                Text = action.Text,
                ActionDateTime = action.ActionDateTime,
                ActionType = action.ActionType
            };

            await _context.UserActions.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<List<UserAction>> GetActionsByUserIdAsync(Guid userId)
        {
            var entities = await _context.UserActions.AsNoTracking().Where(ua => ua.UserId == userId).OrderBy(ua => ua.ActionDateTime).ToListAsync();
            var result = entities.Select(ua => new UserAction(ua.Id, ua.UserId, ua.Text, ua.ActionDateTime, ua.ActionType)).ToList();
            return result;
        }

        public async Task<List<UserAction>> GetAllActionsAsync()
        {
            var entities = await _context.UserActions.AsNoTracking().OrderBy(ua => ua.ActionDateTime).ToListAsync();
            var result = entities.Select(ua => new UserAction(ua.Id, ua.UserId, ua.Text, ua.ActionDateTime, ua.ActionType)).ToList();
            return result;
        }
    }
}
