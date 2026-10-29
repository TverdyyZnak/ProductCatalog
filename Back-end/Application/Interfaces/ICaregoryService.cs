using Application.DTO.CategoryDtos;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface ICaregoryService
    {
        Task<Result<List<CategoryDto>>> GetAllCategoriesAsunc();
    }
}
