using Microsoft.AspNetCore.Mvc;
using Product.WebServer.Models;
using Product.WebServer.Services.ProductService;
using System.Diagnostics;

namespace Product.WebServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {  var response = new Product.WebServer.Services.ProductService.Models.Response.GetProductResponse();        
            try {
            response = new ProductServiceAdapter().GetProductById(1).Data;
            } catch (Exception ex) {

                response.Message = ex.ToString();
            }
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
