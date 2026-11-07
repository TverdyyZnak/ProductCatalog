
using Application.DTO.ProductDtos;
using Domain.Models;
using Domain.Primitives;
using Domain.Primitives.Enums;

namespace Application.DTO.Convertors
{
    public static class ProductConvertor
    {
        public static Result<Product> ToProduct(ProductDtoCreate dto)
        {
            var result = Product.Create
                (
                    Guid.NewGuid(),
                    dto.Name,
                    dto.Description,
                    dto.Price,
                    dto.MainNote,
                    dto.SubNote,
                    dto.CaregoryId,
                    null
                );

            return result;
        }

        public static Result<Product> ToProduct(Guid productId, ProductDtoUpdate dto)
        {
            var result = Product.Create
                (
                    productId,
                    dto.Name,
                    dto.Description,
                    dto.Price,
                    dto.MainNote,
                    dto.SubNote,
                    dto.CaregoryId,
                    null
                );

            return result;
        }

        public static Result<ProductDto> ToDto(Product product)
        {
            if(product.Category == null)
            {
                return Result<ProductDto>.Fail(new ErrorObject(ErrorType.Failure, "Не удалось преобразовать Product в ProductDto"));
            }

            ProductDto dto = new ProductDto
                (
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.MainNote,
                    product.SubNote,
                    product.CategoryId,
                    product.Category.Name
                );

            return Result<ProductDto>.Success(dto);
        }

        public static Result<List<ProductDto>> ToDto(List<Product> products)
        {
            if(products.Any(p => p.Category == null))
            {
                return Result<List<ProductDto>>.Fail(new ErrorObject(ErrorType.Failure, "Не удалось преобразовать Product в ProductDto"));
            }

            var dtos = products
                .Select(p => new ProductDto
                    (
                        p.Id,
                        p.Name,
                        p.Description,
                        p.Price,
                        p.MainNote,
                        p.SubNote,
                        p.CategoryId,
                        p.Category!.Name
                    ))
                .ToList();

            return Result<List<ProductDto>>.Success(dtos);
        }

    }
}
