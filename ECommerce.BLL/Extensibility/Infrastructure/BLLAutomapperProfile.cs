using AutoMapper;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Infrastructure
{
    public class BLLAutomapperProfile : Profile
    {
        public BLLAutomapperProfile()
        {
            this.CreateMap<Category, CategoryDto>();

            this.CreateMap<Product, ProductDto>();
        }
    }
}
