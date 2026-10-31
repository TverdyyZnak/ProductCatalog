using Domain.Exceptions;
using Domain.Models;
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

        public async Task<Guid> CreateAsync(Category category)
        {
            var entity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name
            };

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            int count = await _context.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (count == 0)
            {
                throw new NotFoundException($"Категории с id: {id} не найдена");
            }

            return id;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categoryEntity = await _context.Categories.AsNoTracking().ToListAsync();
            List<Category> categories = categoryEntity.Select(c => Category.Create(c.Id, c.Name).Value).Where(c => c != null).ToList()!;
            return categories;
        }

        public async Task<Category> GetByIdAsync(Guid categoryId)
        {
            var categoryEntity = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == categoryId);
            if(categoryEntity == null)
            {
                throw new NotFoundException($"Категории с id: {categoryId} не найдена");
            }

            var result = Category.Create(categoryEntity.Id, categoryEntity.Name).Value;

            if (result == null)
            {
                throw new InternalServerErrorException($"Данные о категории с id:{categoryId} на сервере повреждены"); 
            }

            return result;
        }

        public async Task<Guid> UpdateAsync(Category category)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if(entity == null)
            {
                throw new NotFoundException($"Категории с id: {category.Id} не найдена");
            }

            entity.Name = category.Name;

            await _context.SaveChangesAsync();

            return category.Id;
        }
    }
}
