using Application.DTO.UserDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByLoginAsync(string login);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<List<UserDto>> GetUserByRoleAsync(UserRole role);
        Task<List<UserDto>> GetUserByActionAsunc(bool isBlocked);
        Task<Guid> DeleteUserAsync(Guid userId);
        Task<Guid> UpdateUserAsync(UpdateUserDto user);
        Task<Guid> UpdateUserPasswordAsync(UpdateUserDto user);
        Task<Guid> BlockUserAsync(Guid id);
        Task<Guid> UnblockUserAsync(Guid id);
        Task<Guid> CreateUserAsync(CreateUserDto user);
    }
}
