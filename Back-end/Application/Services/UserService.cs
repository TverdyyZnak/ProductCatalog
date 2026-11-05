using Application.DTO.Convertors;
using Application.DTO.UserDtos;
using Application.Interfaces;
using Domain.Models;
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
                
            }

            user.Value!.ChangeBlockStatus(true);
            return id;
        }

        public async Task<Guid> DeleteUserAsync(Guid userId)
        {
            var result = await _userRepository.DeleteByIdAsync(userId);

            if (!result.IsSuccess)
            {

            }

            return userId;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllAsync();
            var result = UserConvertor.ToDto(users);

            if (!result.IsSuccess)
            {

            }

            return result.Value!;
        }

        public Task<List<UserDto>> GetUserByActionAsunc(bool isBlocked)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (!user.IsSuccess) 
            {

            }

            var result = UserConvertor.ToDto(user.Value!);

            if (!result.IsSuccess)
            {

            }

            return result.Value!;
        }

        public Task<UserDto> GetUserByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetUserByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            var user = await _userRepository.GetByLoginAsync(login);

            if (!user.IsSuccess)
            {
                //ОШИБКА С ПАРОЛЕМ ИЛИ ЛОГИНОМ
            }

            if (_passwordHasher.VerifyPassword(password, user.Value!.Password))
            {
                return _jwtGenerator.GenerateToken(user.Value);
            }
            else
            {
                throw new Exception("dfdfdf");//ОШИБКА С ПАРОЛЕМ ИЛИ ЛОГИНОМ
            }
        }

        public async Task<string> RegistrationAsync(UserDtoCreate user)
        {
            var newUser = UserConvertor.ToUser(user);

            if (!newUser.IsSuccess) 
            {

            }

            newUser.Value!.ChangePassword(_passwordHasher.HashGenerate(newUser.Value.Password));
            var result = await _userRepository.CreateAsync(newUser.Value);

            if (!result.IsSuccess) 
            {

            }

            return _jwtGenerator.GenerateToken(newUser.Value);
        }

        public async Task<Guid> UnblockUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (!user.IsSuccess)
            {

            }

            user.Value!.ChangeBlockStatus(false);
            return id;
        }

        public async Task<Guid> UpdateUserPasswordAsync(Guid userId, string oldPass, string newPass)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (!user.IsSuccess)
            {

            }

            if (!_passwordHasher.VerifyPassword(oldPass, user.Value!.Password)) 
            {
               //ИСКЛЮЧЕНИЕ
            }

            user.Value.ChangePassword(_passwordHasher.HashGenerate(newPass));

            var result = await _userRepository.UpdateAsync(user.Value);

            if (!result.IsSuccess)
            {

            }

            return userId;
        }
    }
}
