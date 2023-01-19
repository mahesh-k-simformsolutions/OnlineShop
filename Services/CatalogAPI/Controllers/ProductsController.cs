using Catalog.Data.DTO;
using Catalog.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            List<ProductDTO>? products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("pk/{productId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int productId)
        {
            ProductDTO? product = await _productService.GetById(productId);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductDTO product)
        {
            int isSuceess = await _productService.Add(product);
            return isSuceess > 0 ? Ok(isSuceess) : BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductDTO product)
        {
            int isSuceess = await _productService.Update(product);
            return isSuceess > 0 ? Ok() : BadRequest();
        }
        [HttpDelete("delete/{productId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            int isSuceess = await _productService.Delete(productId);
            return isSuceess > 0 ? Ok() : BadRequest();
        }
    }
}
