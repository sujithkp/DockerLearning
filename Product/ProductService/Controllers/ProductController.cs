using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Models.Product> Get()
        {
            yield return new Models.Product()
            {

            };
        }
    }
}