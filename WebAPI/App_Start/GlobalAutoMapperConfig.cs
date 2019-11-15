using AutoMapper;
using ECommerce.WebAPI.Infrastructure;

namespace ECommerce.WebAPI
{
    public static class GlobalAutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new WebApiMappingConfig());
            });
        }
    }
}