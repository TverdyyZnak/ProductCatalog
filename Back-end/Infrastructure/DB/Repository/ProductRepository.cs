using Domain.Models;
using Domain.Primitives;
using Domain.Primitives.Enums;
using Domain.Repositories;
using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> CreateAsync(Product product)
        {
            var entity = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                MainNote = product.MainNote,
                SubNote = product.SubNote,
                CategoryId = product.CategoryId,
            };

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Result<Guid>.Success(entity.Id);
        }

        public async Task<Result<Guid>> DeleteAsync(Guid id)
        {
            int count = await _context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();

            if(count == 0)
            {
                return Result<Guid>.Fail(new ErrorObject(ErrorType.NotFound, $"Продукта с id: {id} не существует"));
            }

            return Result<Guid>.Success(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var entities = await _context.Products.AsNoTracking().ToListAsync();
            List<Product> products = ConvertToProductList(entities);
            return products;
        }

        public async Task<List<Product>> GetByCategoryAsync(Guid categoryId)
        {
            var entities = await _context.Products.AsNoTracking().Where(p => p.CategoryId == categoryId).ToListAsync();
            
            if(entities.Count == 0)
            {
                return new List<Product>();
            }

            List<Product> products = ConvertToProductList(entities);
            return products;
        }

        public async Task<Result<Product>> GetByIdAsync(Guid id)
        {
            var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if(entity == null)
            {
                return Result<Product>.Fail(new ErrorObject(ErrorType.NotFound, $"Продукт с id: {id} не найден"));
            }

            var product = Product.Create(
                entity.Id, 
                entity.Name, 
                entity.Description, 
                entity.Price, 
                entity.MainNote, 
                entity.SubNote, 
                entity.CategoryId, 
                null
            );

            if (!product.IsSuccess) 
            {
                return Result<Product>.Fail(new ErrorObject(ErrorType.Failure, $"Произошла внутренняя ошибка сервера"));
            }

            return Result<Product>.Success(product.Value!);
        }

        public async Task<Result<Guid>> UpdateAsync(Product product)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (entity == null) 
            {
                return Result<Guid>.Fail(new ErrorObject(ErrorType.NotFound, $"Продукт с id: {product.Id} не найден"));
            }

            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.MainNote = product.MainNote;
            entity.SubNote = product.SubNote;
            entity.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return Result<Guid>.Success(entity.Id);
        }

        private List<Product> ConvertToProductList(List<ProductEntity> entities) 
        {
            List<Product> products = entities
                .Select(p => Product.Create(p.Id, p.Name, p.Description, p.Price, p.MainNote, p.SubNote, p.CategoryId, null).Value)
                .Where(p => p != null).ToList()!;
            return products;
        }
    }
}
