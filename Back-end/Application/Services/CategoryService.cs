using Application.DTO.CategoryDtos;
using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository category)
        {
            _categoryRepository = category;
        }

        public async Task<Guid> CreateCategoryAsync(CategoryDto categoryDto)
        {
            Category category = Category.Create(Guid.NewGuid(), categoryDto.Name).Value!;
            var result = await _categoryRepository.CreateAsync(category);
            
            return result.Value;
        }

        public async Task<Guid> DeleteCategoryAsync(Guid categoryId)
        {
            var result = await _categoryRepository.DeleteAsync(categoryId);
            return result.Value;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            List<Category> categories = await _categoryRepository.GetAllAsync();
            return ConvertToCategoryDtoList(categories);
        }

        public async Task<CategoryDto> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return ConvertToCategoryDto(category.Value!);
        }

        public async Task<Guid> UpdateCategoryAsync(CategoryDto category)
        {
            var categoryId = await _categoryRepository.UpdateAsync(ConvertToCategory(category));
            return categoryId.Value;
        }

        private Category ConvertToCategory(CategoryDto categoryDto)
        {
            
            var category = Category.Create(categoryDto.Id!.Value, categoryDto.Name);

            if (!category.IsSuccess)
            {
                throw new UnprocessableEntityException("Нарушены правила валидации на слое Domain"); //СЮДА ПЕРЕДАТЬ ПОТОМ ОБРАБОТЧИК ОШИБОК!!!
            }

            return category.Value!;
        }

        private List<CategoryDto> ConvertToCategoryDtoList(List<Category> categories)
        {
            List<CategoryDto> result = categories.Select(c => new CategoryDto(c.Id, c.Name)).ToList();
            return result;
        }

        private CategoryDto ConvertToCategoryDto(Category category)
        {
            CategoryDto result = new CategoryDto(category.Id, category.Name);
            return result;
        }

    }
}
