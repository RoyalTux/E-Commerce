using AutoMapper;
using ECommerce.DLL.DataEntities;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.DLL.Infrastructure
{
    public class DLLAutomapperProfile : Profile
    {
        public DLLAutomapperProfile()
        {
            this.CreateMap<CategoryDataEntity, Category>()
                .ForMember(x => x.ParentCategory, opt => opt.MapFrom(x => x.ParentCategoryDataEntity))
                .ForMember(x => x.SubCategory, opt => opt.MapFrom(x => x.SubCategoryDataEntities))
                .ReverseMap()
                .MaxDepth(2);

            this.CreateMap<ProductDataEntity, Product>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.CategoryDataEntity))
                .ReverseMap().MaxDepth(2);
        }
    }
}
