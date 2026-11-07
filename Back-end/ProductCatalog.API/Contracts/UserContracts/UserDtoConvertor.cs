using Application.DTO.UserDtos;

namespace ProductCatalog.API.Contracts.UserContracts
{
    public static class UserDtoConvertor
    {
        public static UserResponse ToResponse(UserDto dto)
        {
            UserResponse user = new UserResponse
                (
                    dto.Id,
                    dto.Login,
                    dto.HashPass,
                    dto.IsBlocked,
                    dto.UserRole
                );

            return user;
        }

        public static List<UserResponse> ToResponse(List<UserDto> dtos)
        {
            var users = dtos
                .Select(u => ToResponse(u))
                .ToList();

            return users;
        }

        public static UserDtoCreate ToDto(UserCreateRequest request)
        {
            UserDtoCreate dto = new UserDtoCreate
                (
                    request.Login,
                    request.HashPass,
                    request.IsBlocked,
                    request.UserRole
                );

            return dto;
        }

    }
}
