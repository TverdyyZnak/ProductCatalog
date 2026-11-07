using Application.Commons;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.CategoryContracts;
using System.Security.Claims;
using System.Xml.Linq;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserActionService _userActionService;

        public CategoryController(ICategoryService categoryService, IUserActionService userActionService)
        {
            _categoryService = categoryService;
            _userActionService = userActionService;
        }

        private Guid CurrentUserId
        {
            get
            {
                var userIdClaimor = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaimor != null && Guid.TryParse(userIdClaimor.Value, out var userId))
                {
                    return userId;
                }

                return Guid.Empty;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponse>>> GetAllCategory()
        {
            var result = CategoryDtoConvertor.ConvertToResponse(await _categoryService.GetAllCategoriesAsync());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryById(Guid id)
        {
            var result = CategoryDtoConvertor.ConvertToResponse(await _categoryService.GetCategoryById(id));
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "ProFunctions")]
        public async Task<ActionResult> CreateNewCategory(string name)
        {
            CategoryRequest request = new CategoryRequest(null, name);
            var result = await _categoryService.CreateCategoryAsync(CategoryDtoConvertor.ConvertToDto(request));

            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id: {CurrentUserId} создал категорию {name}", ActionType.Create);
            return Created();
        }

        [HttpDelete]
        [Authorize(Policy = "ProFunctions")]
        public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);

            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id: {CurrentUserId} удалил категорию c id: {id}", ActionType.Delete);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "ProFunctions")]
        public async Task<ActionResult<Guid>> UpdateCategory([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.UpdateCategoryAsync(CategoryDtoConvertor.ConvertToDto(request));

            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id: {CurrentUserId} изменил категорию c id: {request.Id}", ActionType.Update);
            return Ok(result);
        }
    }
}
