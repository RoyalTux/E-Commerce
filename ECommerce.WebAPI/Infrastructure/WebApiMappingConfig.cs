using AutoMapper;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Infrastructure;
using ECommerce.WebAPI.Models;

namespace ECommerce.WebAPI.Infrastructure
{
    public class WebApiMappingConfig : Profile
    {
        public WebApiMappingConfig()
        {
            this.CreateMap<CategoryView, CategoryDto>().ReverseMap().MaxDepth(2);

            this.CreateMap<ProductView, ProductDto>().ReverseMap().MaxDepth(2);

            this.CreateMap<OrderView, OrderDto>()
                .ForMember(dest => dest.OrderLines, opt => opt.Ignore());

            this.CreateMap<OrderLineView, OrderLineDto>()
                .ForMember(dest => dest.Order, opt => opt.Ignore());

            this.CreateMap<FilterCriterias, WebApiFilterCriteria>().ReverseMap();

            this.CreateMap<StateView, StateDto>().ReverseMap();
        }
    }
}