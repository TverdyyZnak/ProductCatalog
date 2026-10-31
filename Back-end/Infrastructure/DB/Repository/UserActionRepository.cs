using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
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

        public async Task<Guid> CreateAsync(UserAction userAction)
        {
            var entity = new UserActionEntity
            {
                Id = userAction.Id,
                Text = userAction.Text,
                ActionDate = userAction.ActionDate,
                UserId = userAction.UserActorId
            };

            await _context.UserActions.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<List<UserAction>> GetAllAsync()
        {
            var entities = await _context.UserActions.AsNoTracking().ToListAsync();
            List<UserAction> result = entities.Select(u => UserAction.Create(u.Id, u.Text, u.ActionDate, u.UserId).Value).ToList()!;
            return result;
        }

        public async Task<List<UserAction>> GetByUserIdAsync(Guid id)
        {
            var entity = await _context.UserActions.AsNoTracking().Where(u => u.Id == id).ToListAsync();
            List<UserAction> result = entity.Select(u => UserAction.Create(u.Id, u.Text, u.ActionDate, u.UserId).Value).ToList()!;
            return result;
        }
    }
}
