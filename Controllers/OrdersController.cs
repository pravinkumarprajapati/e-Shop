using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Model;
using OrderServices.Services;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IProductService _productService;

        public OrdersController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("placeorder")]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            var isValidOrder = true;
            foreach (var product in order.Products)
            {
                if (!_productService.CheckAvailability(product.Id))
                {
                    isValidOrder = false;
                    break;
                }
            }

            if (!isValidOrder)
            {
                return BadRequest("One or more products are not available.");
            }

            // Adjust inventory and create order ID
            foreach (var product in order.Products)
            {
                var inventoryItem = _inventory.FirstOrDefault(i => i.ProductId == product.Id);
                if (inventoryItem != null)
                {
                    inventoryItem.Quantity -= 1; // Adjust inventory count
                }
            }

            order.Id = GetNextOrderId(); // Assume a method to get the next available ID
            return Ok($"Order placed successfully with Order ID: {order.Id}");
        }
    }
}
