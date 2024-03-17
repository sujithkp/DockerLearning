using Microsoft.AspNetCore.Mvc;
using ProductService.Shared.Requests;
using ProductService.Shared;
using Microsoft.Data.SqlClient;
using ProductService.Dal;
using Microsoft.AspNetCore.Hosting.Server;
using ProductService.Shared.Common;
using Serilog;

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

            Log.Logger = new LoggerConfiguration()
                .WriteTo.NewRelicLogs()
                .Enrich.FromLogContext().Enrich.WithProperty("Application", "ProductService")
                .CreateLogger();
        }

        [HttpGet(Name = "GetProduct")]
        public GenericResponse<GetProductResponse> Get()
        {
            try
            {
                if (DateTime.Now.Millisecond % 13 == 0)
                {
                    Log.ForContext("SessionId", DateTime.Now.ToFileTime())
                        .Information("Payment Declined.");
                }
                else
                {
                    Log.ForContext("SessionId", DateTime.Now.ToFileTime())
                    .Information("Payment Accepted.");
                }


                return new GenericResponse<GetProductResponse>()
                {
                    Data = _productService.GetProducts(null),
                    ErrorMessage = null,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
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
