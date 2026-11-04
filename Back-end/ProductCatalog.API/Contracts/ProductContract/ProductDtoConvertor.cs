using Application.DTO.ProductDtos;

namespace ProductCatalog.API.Contracts.ProductContract
{
    public static class ProductDtoConvertor
    {
        public static ProductResponse ToResponse(ProductDto dto)
        {
            ProductResponse response = new ProductResponse
                (
                    dto.Id,
                    dto.Name,
                    dto.Description,
                    dto.Price,
                    dto.MainNote,
                    dto.SubNote,
                    dto.CaregoryId,
                    dto.CategoryName
                );

            return response;
        }

        public static List<ProductResponse> ToResponse(List<ProductDto> dtos)
        {
            var result = dtos.Select(p => ToResponse(p)).ToList();
            return result;
        }

        public static ProductDtoCreate ToDto(ProductCreateRequest request)
        {
            ProductDtoCreate result = new ProductDtoCreate
                (
                    request.Name,
                    request.Description,
                    request.Price,
                    request.MainNote,
                    request.SubNote,
                    request.CaregoryId
                );

            return result;
        }

        public static ProductDtoUpdate ToDto(ProductUpdateRequest request)
        {
            ProductDtoUpdate result = new ProductDtoUpdate
                (
                    request.Name,
                    request.Description,
                    request.Price,
                    request.MainNote,
                    request.SubNote,
                    request.CaregoryId
                );

            return result;
        }
    }
}
