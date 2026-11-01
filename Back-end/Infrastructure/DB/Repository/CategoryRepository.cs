using Domain.Models;
using Domain.Primitives;
using Domain.Primitives.Enums;
using Domain.Repositories;
using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> CreateAsync(Category category)
        {
            var entity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name
            };

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Result<Guid>.Success(entity.Id);
        }

        public async Task<Result<Guid>> DeleteAsync(Guid id)
        {
            int count = await _context.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (count == 0)
            {
                return Result<Guid>.Fail(new ErrorObject(ErrorType.NotFound, $"Категории с id: {id} не найдена"));
            }

            return Result<Guid>.Success(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categoryEntity = await _context.Categories.AsNoTracking().ToListAsync();
            List<Category> categories = categoryEntity.Select(c => Category.Create(c.Id, c.Name).Value).Where(c => c != null).ToList()!;
            return categories;
        }

        public async Task<Result<Category>> GetByIdAsync(Guid categoryId)
        {
            var categoryEntity = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == categoryId);
            if(categoryEntity == null)
            {
                return Result<Category>.Fail(new ErrorObject(ErrorType.NotFound, $"Категории с id: {categoryId} не найдена"));
            }

            var result = Category.Create(categoryEntity.Id, categoryEntity.Name).Value;

            if (result == null)
            {
                return Result<Category>.Fail(new ErrorObject(ErrorType.Failure, $"Произошла внутренняя ошибка сервера")); 
            }

            return Result<Category>.Success(result);
        }

        public async Task<Result<Guid>> UpdateAsync(Category category)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if(entity == null)
            {

                return Result<Guid>.Fail(new ErrorObject(ErrorType.NotFound, $"Категории с id: {category.Id} не найдена"));
            }

            entity.Name = category.Name;

            await _context.SaveChangesAsync();

            return Result<Guid>.Success(entity.Id);
        }
    }
}
