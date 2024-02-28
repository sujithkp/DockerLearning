namespace Product.WebServer.Services.ProductService.Models.Response
{
    public class GetProductResponse
    {
        public GetProductResponse()
        {
            this.Products = new List<ProductDto>();
        }

        public IList<ProductDto> Products { get; set; }

        public string Message { get; set; }
    }
}
