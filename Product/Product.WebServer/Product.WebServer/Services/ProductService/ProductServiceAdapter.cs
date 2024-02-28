using Product.WebServer.Common;
using Product.WebServer.Services.ProductService.Models.Response;
using RestSharp;

namespace Product.WebServer.Services.ProductService
{
    public class ProductServiceAdapter
    {
        private readonly Uri _baseUri = new Uri("http://product-api:5215/");

        public ProductServiceAdapter()
        {

        }

        public GenericResponse<GetProductResponse> GetProductById(int id)
        {
            var client = new RestSharp.RestClient(_baseUri);

            var response = client.Get<GenericResponse<GetProductResponse>>(new RestRequest()
            {
                Resource = "/product",
            });

            return response;
        }
    }
}
