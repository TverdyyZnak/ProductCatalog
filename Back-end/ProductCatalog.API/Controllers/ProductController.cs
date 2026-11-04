using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Contracts.ProductContract;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            var result = await _productService.GetAllProductsAsync();
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
        public async Task<ActionResult<Guid>> CreateNewProduct([FromBody] ProductCreateRequest request)
        {
            var result = await _productService.CreateProductAsync(ProductDtoConvertor.ToDto(request));
            return CreatedAtAction("new product id", result);
        }

        [HttpDelete("{productId:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid productId)
        {
            var result = await _productService.DeleteProductAsync(productId);
            return Ok(result);
        }

        [HttpPut("{productId:guid}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid productId, [FromBody] ProductUpdateRequest request)
        {
            var result = await _productService.UpdateProductAsync(productId, ProductDtoConvertor.ToDto(request));
            return Ok(result);
        }
    }
}
