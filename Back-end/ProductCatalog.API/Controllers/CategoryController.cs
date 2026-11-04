using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.CategoryContracts;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        public async Task<ActionResult<Guid>> CreateNewCategory(string name)
        {
            CategoryRequest request = new CategoryRequest(null, name);
            var result = await _categoryService.CreateCategoryAsync(CategoryDtoConvertor.ConvertToDto(request));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateCategory([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.UpdateCategoryAsync(CategoryDtoConvertor.ConvertToDto(request));
            return Ok(result);
        }
    }
}
