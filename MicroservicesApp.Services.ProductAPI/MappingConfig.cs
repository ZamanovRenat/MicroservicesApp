using AutoMapper;
using MicroservicesApp.Services.ProductAPI.Models;
using MicroservicesApp.Services.ProductAPI.Models.DTO;

namespace MicroservicesApp.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();

                //Можно применить
                //config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
