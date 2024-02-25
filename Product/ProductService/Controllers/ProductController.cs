using Microsoft.AspNetCore.Mvc;
using ProductService.Shared.Requests;
using ProductService.Shared;
using Microsoft.Data.SqlClient;
using ProductService.Dal;
using Microsoft.AspNetCore.Hosting.Server;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetProduct")]
        public GetProductResponse Get()
        {
            var response = _productService.GetProducts(null);
            return response;
        }
    }
}
