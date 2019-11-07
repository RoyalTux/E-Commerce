using AutoMapper;
using BLL.Extensibility.Dto;
using BLL.Extensibility.Infrastructure;
using WebAPI.Models;

namespace WebAPI.Infrastructure
{
    public class WebApiMappingConfig : Profile
    {
        public WebApiMappingConfig()
        {
            this.CreateMap<CategoryView, CategoryDto>().ReverseMap().MaxDepth(2);

            this.CreateMap<ProductView, ProductDto>().ReverseMap().MaxDepth(2);

            this.CreateMap<OrderView, OrderDto>().ReverseMap().MaxDepth(2);

            this.CreateMap<FilterCriterias, WebApiFilterCriteria>().ReverseMap();

            this.CreateMap<StateView, StateDto>().ReverseMap();
        }
    }
}