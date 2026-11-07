using Application.Commons;
using Application.Commons.Exceptions;
using Application.DTO.CategoryDtos;
using Application.DTO.Convertors;
using Application.Interfaces;
using Domain.Models;
using Domain.Repositories;
using System.Globalization;

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
            if(categoryDto.Name.Length > ValidationTypes._maxNameLength)
            {
                throw new UnprocessableEntityException($"Длина поля Name больше {ValidationTypes._maxNameLength}");
            }


            Category category = Category.Create(Guid.NewGuid(), categoryDto.Name).Value!;
            var result = await _categoryRepository.CreateAsync(category);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value;
        }

        public async Task<Guid> DeleteCategoryAsync(Guid categoryId)
        {
            var result = await _categoryRepository.DeleteAsync(categoryId);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            List<Category> categories = await _categoryRepository.GetAllAsync();
            return CategoryConvertor.ConvertToCategoryDtoList(categories);
        }

        public async Task<CategoryDto> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return CategoryConvertor.ConvertToCategoryDto(category.Value!);
        }

        public async Task<Guid> UpdateCategoryAsync(CategoryDto category)
        {
            if (category.Name.Length > ValidationTypes._maxNameLength)
            {
                throw new UnprocessableEntityException($"Длина поля Name больше {ValidationTypes._maxNameLength}");
            }

            var result = await _categoryRepository.UpdateAsync(CategoryConvertor.ConvertToCategory(category));

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value;
        }
    }
}
