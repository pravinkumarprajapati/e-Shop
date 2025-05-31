using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web1.Data;
using Web1.Model;

namespace web1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
      

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ProductContext _productContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ProductContext productContext )
    {
        _logger = logger;
        _productContext = productContext;
    }
    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        try
        {
            _logger.LogInformation("Fetching all products from database.");
            return await _productContext.Products.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all products.");
            throw new Exception("Failed to retrieve products.", ex);
        }
    }     
}
