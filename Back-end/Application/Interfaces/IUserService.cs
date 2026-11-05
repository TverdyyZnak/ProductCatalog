using Application.DTO.UserDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByLoginAsync(string login);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<List<UserDto>> GetUserByRoleAsync(string role);
        Task<List<UserDto>> GetUserByActionAsunc(bool isBlocked);
        Task<Guid> DeleteUserAsync(Guid userId);
        Task<Guid> UpdateUserPasswordAsync(Guid userId, string oldPass, string newPass);
        Task<Guid> BlockUserAsync(Guid id);
        Task<Guid> UnblockUserAsync(Guid id);
        Task<string> RegistrationAsync(UserDtoCreate user);
        Task<string> Login(string login, string password);
    }
}
