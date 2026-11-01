using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.CategoryContracts;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryResponse>> GetAllCategory() 
        {
            var result = CategoryDtoConvertor.ConvertToResponse(await _categoryService.GetAllCategoriesAsync());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewCategory(string name) 
        {
            CategoryRequest request = new CategoryRequest(null, name);
            var result = await _categoryService.CreateCategoryAsync(CategoryDtoConvertor.ConvertToDto(request));
            return Ok(result);
        }
    }
}
