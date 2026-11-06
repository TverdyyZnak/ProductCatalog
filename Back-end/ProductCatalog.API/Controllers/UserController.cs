using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.UserContracts;
using System.Security.Claims;
using Application.Commons;
using Domain.Models;
using Application.Commons.Exceptions;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserActionService _userActionService;
        public UserController(IUserService userService, IUserActionService userActionService)
        {
            _userService = userService;
            _userActionService = userActionService;
        }

        private Guid CurrentUserId
        {
            get
            {
                var userIdClaimor = User.FindFirst(ClaimTypes.NameIdentifier);
                if(userIdClaimor != null && Guid.TryParse(userIdClaimor.Value, out var userId))
                {
                    return userId;
                }

                return Guid.Empty;
            }
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(UserDtoConvertor.ToResponse(users));
        }

        [HttpPost("registration")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<string>> Registration([FromBody] UserCreateRequest request)
        {
            var result = await _userService.RegistrationAsync(UserDtoConvertor.ToDto(request));

            await _userActionService.CreateAction(CurrentUserId, $"Администратор создал нового пользователя c логином {request.Login}", ActionType.Create);
            return Created();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginRequest request)
        {
            var result = await _userService.LoginAsync(request.Login, request.Password);
            HttpContext.Response.Cookies.Append("JCook", result.Jwt);

            await _userActionService.CreateAction(result.UserId, $"Пользователь с id:{result.UserId} вошел в систему", ActionType.Login);
            return Ok();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("JCook");
            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id:{CurrentUserId} вышел из системы", ActionType.Logout);
            return Ok();
        }

        [HttpPost("blocking")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<Guid>> BlockUser(Guid userId)
        {
            var result = await _userService.BlockUserAsync(userId);

            await _userActionService.CreateAction(CurrentUserId, $"Администратор заблокировал пользователя с id:{userId}", ActionType.Block);
            return Ok(result);
        }

        [HttpPost("unblocking")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<Guid>> UnblockUser(Guid userId)
        {
            var result = await _userService.UnblockUserAsync(userId);
            await _userActionService.CreateAction(CurrentUserId, $"Администратор разблокировал пользователя с id:{userId}", ActionType.Unblock);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            if(id == CurrentUserId)
            {
                throw new UnprocessableEntityException("Администратор не может удалить сам себя");
            }

            var result = await _userService.DeleteUserAsync(id);
            await _userActionService.CreateAction(CurrentUserId, $"Администратор удалил пользователя с id:{id}", ActionType.Delete);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<Guid>> ChangePassword([FromBody] UserPasswordUpdateRequest request)
        {
            var result = await _userService.UpdateUserPasswordAsync(request.UserId, request.OldPassword, request.NewPassword);

            await _userActionService.CreateAction(CurrentUserId, $"Администратор изменил пароль пользователя с id:{request.UserId}", ActionType.Update);
            return Ok(result);
        }
    }
}
