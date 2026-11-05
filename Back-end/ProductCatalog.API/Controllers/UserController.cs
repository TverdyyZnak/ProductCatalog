using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.UserContracts;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "ProFunctions")]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(UserDtoConvertor.ToResponse(users));
        }

        [HttpPost("registration")]
        public async Task<ActionResult<string>> Registration([FromBody] UserCreateRequest request)
        {
            var result = await _userService.RegistrationAsync(UserDtoConvertor.ToDto(request));
            HttpContext.Response.Cookies.Append("JCook", result);
            return Created();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginRequest request)
        {
            var result = await _userService.LoginAsync(request.Login, request.Password);
            HttpContext.Response.Cookies.Append("JCook", result);
            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("JCook");
            return Ok();
        }
    }
}
