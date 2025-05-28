using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Services;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("checkavailability/{productId}")]
        public IActionResult CheckAvailability(int productId)
        {
            bool isAvailable = _productService.CheckAvailability(productId);
            if (isAvailable)
            {
                return Ok($"Product with ID {productId} is available.");
            }
            else
            {
                return NotFound($"Product with ID {productId} is not available.");
            }
        }
    }
}
