using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Model;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpPost("processpayment")]
        public IActionResult ProcessPayment([FromBody] Payment payment)
        {
            // Logic to process payment and update order status if successful
            if (payment.Status == "Success")
            {
                return Ok("Payment processed successfully.");
            }
            else
            {
                return BadRequest("Payment failed.");
            }
        }
    }
}
