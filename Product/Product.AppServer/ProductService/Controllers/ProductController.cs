using Microsoft.AspNetCore.Mvc;
using ProductService.Shared.Requests;
using ProductService.Shared;
using Microsoft.Data.SqlClient;
using ProductService.Dal;
using Microsoft.AspNetCore.Hosting.Server;
using ProductService.Shared.Common;

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
        public GenericResponse<GetProductResponse> Get()
        {
            try
            {
                return new GenericResponse<GetProductResponse>()
                {
                    Data = _productService.GetProducts(null),
                    ErrorMessage = null,
                    IsSuccess = true
                };
            }catch (Exception ex)
            {
                return new GenericResponse<GetProductResponse>()
                {
                    Data = null,
                    ErrorMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}
