using Application.Commons;
using Application.DTO.Convertors;
using Application.DTO.UserDtos;
using Application.Interfaces;
using Domain.Models;
using Domain.Primitives;
using Domain.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<Guid> BlockUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (!user.IsSuccess) 
            {
                ExceptionAnalyst.ThrowException(user.Error);
            }

            user.Value!.ChangeBlockStatus(true);
            var result = await _userRepository.UpdateAsync(user.Value);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return id;
        }

        public async Task<Guid> DeleteUserAsync(Guid userId)
        {
            var result = await _userRepository.DeleteByIdAsync(userId);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return userId;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllAsync();
            var result = UserConvertor.ToDto(users);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (!user.IsSuccess) 
            {
                ExceptionAnalyst.ThrowException(user.Error);
            }

            var result = UserConvertor.ToDto(user.Value!);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }

        public async Task<UserLogin> LoginAsync(string login, string password)
        {
            var user = await _userRepository.GetByLoginAsync(login);

            if (!user.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(user.Error);
            }

            if (_passwordHasher.VerifyPassword(password, user.Value!.Password))
            {
                return new UserLogin(user.Value.Id, _jwtGenerator.GenerateToken(user.Value));
            }
            else
            {
                throw new Exception("Неверный логин или пароль");
            }
        }

        public async Task<string> RegistrationAsync(UserDtoCreate user)
        {
            var newUser = UserConvertor.ToUser(user);

            if (!newUser.IsSuccess) 
            {
                ExceptionAnalyst.ThrowException(newUser.Error);

            }

            newUser.Value!.ChangePassword(_passwordHasher.HashGenerate(newUser.Value.Password));
            var result = await _userRepository.CreateAsync(newUser.Value);

            if (!result.IsSuccess) 
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return _jwtGenerator.GenerateToken(newUser.Value);
        }

        public async Task<Guid> UnblockUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (!user.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(user.Error);
            }

            user.Value!.ChangeBlockStatus(false);
            var result = await _userRepository.UpdateAsync(user.Value);

            if(!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);

            }

            return id;
        }

        public async Task<Guid> UpdateUserPasswordAsync(Guid userId, string oldPass, string newPass)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (!user.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(user.Error);
            }

            if (!_passwordHasher.VerifyPassword(oldPass, user.Value!.Password)) 
            {
                throw new Exception("Неверный пароль");
            }

            user.Value.ChangePassword(_passwordHasher.HashGenerate(newPass));

            var result = await _userRepository.UpdateAsync(user.Value);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return userId;
        }
    }
}
