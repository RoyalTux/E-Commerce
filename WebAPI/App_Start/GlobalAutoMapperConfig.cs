using AutoMapper;
using WebAPI.Infrastructure;

namespace WebAPI
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