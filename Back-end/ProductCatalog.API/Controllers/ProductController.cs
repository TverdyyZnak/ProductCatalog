using Application.Commons;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.ProductContract;
using ProductCatalog.API.Contracts.ProductContracts;
using System.Security.Claims;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserActionService _userActionService;
        public ProductController(IProductService productService, IUserActionService userActionService)
        {
            _productService = productService;
            _userActionService = userActionService;
        }

        private Guid CurrentUserId
        {
            get
            {
                var userIdClaimor = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaimor != null && Guid.TryParse(userIdClaimor.Value, out var userId))
                {
                    return userId;
                }

                return Guid.Empty;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetProducts([FromQuery] ProductFiltreRequest request)
        {
            var result = await _productService.GetProductByFilter(ProductDtoConvertor.ToDto(request));
            return Ok(ProductDtoConvertor.ToResponse(result));
        }

        [HttpGet("category/{categoryId:guid}")]
        public async Task<ActionResult<List<ProductResponse>>> GetProductsByCategory(Guid categoryId)
        {
            var result = await _productService.GetProductsByCategoryAsync(categoryId);
            return Ok(ProductDtoConvertor.ToResponse(result));
        }

        [HttpGet("{productId:guid}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(Guid productId)
        {
            var result = await _productService.GetProductByIdAsync(productId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "StandartFunctions")]
        public async Task<ActionResult<Guid>> CreateNewProduct([FromBody] ProductCreateRequest request)
        {
            var result = await _productService.CreateProductAsync(ProductDtoConvertor.ToDto(request));

            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id: {CurrentUserId} создал продукт с id {result}", ActionType.Create);
            return Created();
        }

        [HttpDelete("{productId:guid}")]
        [Authorize(Policy = "ProFunctions")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid productId)
        {
            var result = await _productService.DeleteProductAsync(productId);

            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id: {CurrentUserId} удалил продукт с id: {productId}", ActionType.Delete);
            return Ok(result);
        }

        [HttpPut("{productId:guid}")]
        [Authorize(Policy = "StandartFunctions")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid productId, [FromBody] ProductUpdateRequest request)
        {
            var result = await _productService.UpdateProductAsync(productId, ProductDtoConvertor.ToDto(request));
            
            await _userActionService.CreateAction(CurrentUserId, $"Пользователь с id: {CurrentUserId} обновил продукт с id: {productId}", ActionType.Update);
            return Ok(result);
        }
    }
}
