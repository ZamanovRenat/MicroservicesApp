using AutoMapper;
using MicroservicesApp.Services.CouponAPI.Models;
using MicroservicesApp.Services.CouponAPI.Models.Dto;

namespace MicroservicesApp.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
