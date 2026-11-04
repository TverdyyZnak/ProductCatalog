
using Application.DTO.CategoryDtos;
using Application.DTO.Convertors;
using Application.DTO.ProductDtos;
using Application.Interfaces;
using Domain.Models;
using Domain.Repositories;
using System.ComponentModel.DataAnnotations;

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
            var product = ProductConvertor.ToProduct(productDto);

            if (!product.IsSuccess)
            {
                //ТУТ ОБРАБОТКА ОШИБОК
            }

            var result = await _productRepositort.CreateAsync(product.Value!);

            if (!result.IsSuccess)
            {
                //ТУТ ОБРАБОТКА ОШИБОК
            }

            return result.Value;
        }

        public async Task<Guid> DeleteProductAsync(Guid id)
        {
            var result = await _productRepositort.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                //ТУТ ОБРАБОТКА ОШИБОК
            }

            return result.Value;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var responseList = await _productRepositort.GetAllAsync();
            var result =  ProductConvertor.ToDto(responseList);

            if (!result.IsSuccess) 
            {
                //ТУТ ОБРАБОТКА ОШИБОК
            }

            return result.Value!;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var response = await _productRepositort.GetByIdAsync(id);

            if (!response.IsSuccess)
            {
                ////ТУТ ОБРАБОТКА ОШИБОК
            }

            var result = ProductConvertor.ToDto(response.Value!);

            if (!result.IsSuccess)
            {
                ////ТУТ ОБРАБОТКА ОШИБОК
            }

            return result.Value!;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var responseList = await _productRepositort.GetByCategoryAsync(categoryId);
            var result = ProductConvertor.ToDto(responseList);

            if (!result.IsSuccess)
            {
                ////ТУТ ОБРАБОТКА ОШИБОК
            }

            return result.Value!;
        }

        public Task<List<ProductDto>> GetProductsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByPriceAsync(decimal Price)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateProductAsync(Guid id, ProductDtoUpdate productDto)
        {
            throw new NotImplementedException();
        }
    }
}
