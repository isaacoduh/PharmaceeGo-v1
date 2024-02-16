using AutoMapper;
using PharmaceeGo.Services.CouponAPI.Dto;
using PharmaceeGo.Services.CouponAPI.Models;

namespace PharmaceeGo.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}