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


            SqlConnection connection = new SqlConnection("Server = 192.168.29.52; Database = Northwind; User Id = sa; Password = Cbse#1728;Encrypt=false;TrustServerCertificate=true;");
            connection.Open();


            var response = _productService.GetProducts(null);

            response.Message = connection.State.ToString();

            return response;
        }
    }
}
