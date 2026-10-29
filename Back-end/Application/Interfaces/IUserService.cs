using Application.DTO.UserDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<List<UserDto>>> GetAllUsersAsync();
        Task<Result<UserDto>> GetUserByLoginAsync(string login);
        Task<Result<UserDto>> GetUserByIdAsync(Guid id);
        Task<Result<List<UserDto>>> GetUserByRoleAsync(UserRole role);
        Task<Result<List<UserDto>>> GetUserByActionAsunc(bool isBlocked);
        Task<Result<Guid>> DeleteUserAsync(Guid userId);
        Task<Result<Guid>> UpdateUserAsync(UpdateUserDto user);
        Task<Result<Guid>> UpdateUserPasswordAsync(UpdateUserDto user);
        Task<Result<Guid>> BlockUserAsync(Guid id);
        Task<Result<Guid>> UnblockUserAsync(Guid id);
        Task<Result<Guid>> CreateUserAsync(CreateUserDto user);
    }
}
