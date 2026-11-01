using Application.DTO.CategoryDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryById(Guid id);
        Task<Guid> CreateCategoryAsync(CategoryDto category);
        Task<Guid> DeleteCategoryAsync(Guid categoryId);
        Task<Guid> UpdateCategoryAsync(CategoryDto category);   
    }
}
