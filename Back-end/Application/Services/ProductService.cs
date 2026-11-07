
using Application.Commons;
using Application.Commons.Exceptions;
using Application.DTO.Convertors;
using Application.DTO.ProductDtos;
using Application.Interfaces;
using Domain.Repositories;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepositort;
        private readonly ICategoryRepository _categoryRepositort;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepositort)
        {
            _productRepositort = productRepository;
            _categoryRepositort = categoryRepositort;
        }

        public async Task<Guid> CreateProductAsync(ProductDtoCreate productDto)
        {
            if(productDto.SubNote.Length > ValidationTypes._maxNoteLength || productDto.MainNote.Length > ValidationTypes._maxNoteLength)
            {
                throw new UnprocessableEntityException($"Длина полей примечаний больше {ValidationTypes._maxNoteLength}");
            }

            if (productDto.Name.Length > ValidationTypes._maxNameLength)
            {
                throw new UnprocessableEntityException($"Длина названия больше {ValidationTypes._maxNameLength}");
            }

            if (productDto.Description.Length > ValidationTypes._maxDescriptionLength)
            {
                throw new UnprocessableEntityException($"Длина описания больше {ValidationTypes._maxDescriptionLength}");
            }

            var product = ProductConvertor.ToProduct(productDto);

            if (!product.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(product.Error);
            }

            var result = await _productRepositort.CreateAsync(product.Value!);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value;
        }

        public async Task<Guid> DeleteProductAsync(Guid id)
        {
            var result = await _productRepositort.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var responseList = await _productRepositort.GetAllAsync();
            var result =  ProductConvertor.ToDto(responseList);

            if (!result.IsSuccess) 
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }

        public async Task<List<ProductDto>> GetProductByFilter(ProductFiltre filtre)
        {
            var products = await _productRepositort.GetProductByFiltre(filtre.SearchName, filtre.MinPrice, filtre.MaxPrice, filtre.CategoryId, filtre.SortBy);
            var result = ProductConvertor.ToDto(products);

            if (!result.IsSuccess) 
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var response = await _productRepositort.GetByIdAsync(id);

            if (!response.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(response.Error);
            }

            var result = ProductConvertor.ToDto(response.Value!);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var responseList = await _productRepositort.GetByCategoryAsync(categoryId);
            var result = ProductConvertor.ToDto(responseList);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }

        public async Task<Guid> UpdateProductAsync(Guid id, ProductDtoUpdate productDto)
        {
            if (productDto.SubNote.Length > ValidationTypes._maxNoteLength || productDto.MainNote.Length > ValidationTypes._maxNoteLength)
            {
                throw new UnprocessableEntityException($"Длина полей примечаний больше {ValidationTypes._maxNoteLength}");
            }

            if (productDto.Name.Length > ValidationTypes._maxNameLength)
            {
                throw new UnprocessableEntityException($"Длина названия больше {ValidationTypes._maxNameLength}");
            }

            if (productDto.Description.Length > ValidationTypes._maxDescriptionLength)
            {
                throw new UnprocessableEntityException($"Длина описания больше {ValidationTypes._maxDescriptionLength}");
            }

            var product = ProductConvertor.ToProduct(id, productDto);

            if (!product.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(product.Error);
            }

            var result = await _productRepositort.UpdateAsync(product.Value!);

            if (!result.IsSuccess)
            {
                ExceptionAnalyst.ThrowException(result.Error);
            }

            return result.Value!;
        }
    }
}
