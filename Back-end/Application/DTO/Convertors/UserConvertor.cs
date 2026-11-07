using Application.Commons.Exceptions;
using Application.DTO.UserDtos;
using Domain.Models;
using Domain.Primitives;
using Domain.Primitives.Enums;

namespace Application.DTO.Convertors
{
    public static class UserConvertor
    {
        public static Result<UserDto> ToDto(User user)
        {
            UserDto dto = new UserDto
                (
                    user.Id,
                    user.Login,
                    user.Password,
                    user.IsBlocked,
                    user.UserRole.ToString()
                );
            
            return Result<UserDto>.Success(dto);
        } 

        public static Result<List<UserDto>> ToDto(List<User> users)
        {
            var dtoList = users.Select(u => new UserDto(u.Id, u.Login, u.Password, u.IsBlocked, u.UserRole.ToString())).ToList();
            return Result<List<UserDto>>.Success(dtoList);
        }

        public static Result<User> ToUser(UserDtoCreate dto)
        {
            var user = User.Create(Guid.NewGuid(), dto.Login, dto.Password, dto.IsBlocked, ConvertRole(dto.UserRole));

            if (!user.IsSuccess)
            {

            }

            return user;
        }

        private static Role ConvertRole(string role)
        {
            switch (role)
            {
                case "User":
                    return Role.User;
                case "ProUser":
                    return Role.ProUser;
                case "Admin":
                    return Role.Admin;
                default:

                    throw new UnprocessableEntityException("В поле 'Role' передан неверный аргумен");
            }
        }
    }
}
