using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.UserActionContracts;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/actions")]
    public class UserActionController : ControllerBase
    {
        private readonly IUserActionService _userActionService;
        public UserActionController(IUserActionService userAction)
        {
            _userActionService = userAction;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<List<UserActionResponse>>> GetAllUserActions()
        {
            var result = await _userActionService.GetUserActions();
            return Ok(UserActionDtoConvertor.ToResponse(result));
        }

        [HttpGet("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<List<UserActionResponse>>> GetAllUserActions(Guid id)
        {
            var result = await _userActionService.GetUserActionByIdAsync(id);
            return Ok(UserActionDtoConvertor.ToResponse(result));
        }
    }
}
