using Application.DTO.CategoryDtos;

namespace ProductCatalog.API.Contracts.CategoryContracts
{
    public static class CategoryDtoConvertor
    {
        public static CategoryDto ConvertToDto(CategoryRequest request) 
        {
            CategoryDto dto = new CategoryDto(request.Id, request.Name);
            return dto;
        }

        public static CategoryResponse ConvertToResponse(CategoryDto dto)
        {
            CategoryResponse responce = new CategoryResponse(dto.Id!.Value, dto.Name);
            return responce;
        }

        public static List<CategoryResponse> ConvertToResponse(List<CategoryDto> dto)
        {
            List<CategoryResponse> response = dto.Select(c => new CategoryResponse(c.Id!.Value, c.Name)).ToList();
            return response;
        }
    }
}
