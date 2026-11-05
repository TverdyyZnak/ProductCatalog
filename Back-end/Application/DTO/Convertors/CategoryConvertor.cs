using Application.Commons;
using Application.DTO.CategoryDtos;
using Domain.Models;

namespace Application.DTO.Convertors
{
    public class CategoryConvertor
    {
        public static Category ConvertToCategory(CategoryDto categoryDto)
        {

            var category = Category.Create(categoryDto.Id!.Value, categoryDto.Name);

            if (!category.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(category.Error);
            }

            return category.Value!;
        }

        public static List<CategoryDto> ConvertToCategoryDtoList(List<Category> categories)
        {
            List<CategoryDto> result = categories.Select(c => new CategoryDto(c.Id, c.Name)).ToList();
            return result;
        }

        public static CategoryDto ConvertToCategoryDto(Category category)
        {
            CategoryDto result = new CategoryDto(category.Id, category.Name);
            return result;
        }
    }
}
