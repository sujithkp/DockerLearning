using Product.WebServer.Common;

namespace Product.WebServer.Services.ProductService
{
    public class ProductServiceAdapter
    {
        public ProductServiceAdapter()
        {

        }

        public GenericResponse<Product> GetProductById(int id)
        {
            var response = new GenericResponse<Product>();
            response.Data = new Product
            {
                Id = id,
                Name = "Product Name",
                Description = "Product Description",
                Price = 100
            };
            response.Success = true;
            return response;
        }
    }
}
}
