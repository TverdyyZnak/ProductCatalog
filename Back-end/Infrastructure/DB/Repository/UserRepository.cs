using Domain.Exceptions;
using Domain.Models;
using Domain.Primitives.Enums;
using Domain.Repositories;
using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(User user)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Login == user.Login);

            if (userEntity != null) 
            {
                throw new LoginAlreadyTakenException($"Пользователь с данным логином уже существует");
            }

            var entity = new UserEntity
            {
                Id = user.Id,
                Login = user.Login,
                HashPassword = user.Password,
                IsBlocked = user.IsBlocked,
                Role = user.UserRole.ToString()
            };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> DeleteByIdAsync(Guid id)
        {
            int count = await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            
            if(count == 0)
            {
                throw new NotFoundException($"Пользователь с id: {id} не найден");
            }

            return id;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var entities = await _context.Users.AsNoTracking().ToListAsync();

            List<User> result = entities
                .Select(u => User.Create(u.Id, u.Login, u.HashPassword, u.IsBlocked, Enum.Parse<Role>(u.Role)).Value)
                .Where(u => u != null)
                .ToList()!;

            return result;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var entity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            
            if (entity == null)
            {
                throw new NotFoundException($"Пользователь с id: {id} не найден");
            }

            var result = User.Create(entity.Id, entity.Login, entity.HashPassword, entity.IsBlocked, Enum.Parse<Role>(entity.Role)).Value;

            if(result == null)
            {
                throw new InternalServerErrorException($"Произошла внутренняя ошибка сервера");
            }

            return result;
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            var entity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login);

            if (entity == null)
            {
                throw new NotFoundException($"Пользователь с логином: {login} не найден");
            }

            var result = User.Create(entity.Id, entity.Login, entity.HashPassword, entity.IsBlocked, Enum.Parse<Role>(entity.Role)).Value;

            if (result == null)
            {
                throw new InternalServerErrorException($"Произошла внутренняя ошибка сервера");
            }

            return result;
        }

        public async Task<List<User>> GetByRoleAsync(Role role)
        {
            var entities = await _context.Users.AsNoTracking().Where(u => u.Role == role.ToString()).ToListAsync();
            List<User> result = entities
                .Select(u => User.Create(u.Id, u.Login, u.HashPassword, u.IsBlocked, Enum.Parse<Role>(u.Role)).Value)
                .Where(u => u != null)
                .ToList()!;

            return result;
        }

        public async Task<Guid> UpdateAsync(User user)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (entity == null) 
            {
                throw new NotFoundException($"Пользователя с id: {user.Id} не найден");
            }

            entity.Login = user.Login;
            entity.HashPassword = user.Password;
            entity.IsBlocked = user.IsBlocked;
            entity.Role = user.UserRole.ToString();

            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
