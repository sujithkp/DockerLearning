using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductService.Dal.Entities;
using ProductService.Dal.Mappers;
using ProductService.Shared.Dto.Entities;

namespace ProductService.Dal
{
    public class ProductDal
    {
        private readonly IMapper _mapper;

        private readonly NWindProductContext _dbContext;

        public ProductDal()
        {
            //Provide all the Mapping Configuration
            _mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

            var optionBuilder = new DbContextOptionsBuilder<NWindProductContext>();
            optionBuilder.UseLazyLoadingProxies();
            optionBuilder.UseSqlServer("Server=192.168.29.52;Database=Northwind;User Id=sa;Password=Cbse#1728;Encrypt=false;TrustServerCertificate=true;");
            var context = new NWindProductContext(optionBuilder.Options);
        }

        public IList<ProductDto> GetProducts()
        {
            var products = _dbContext.Products.ToList();

            return _mapper.Map<IList<Product>, IList<ProductDto>>(products);
        }
    }

    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());  
            });

            return config;
        }
    }
}
