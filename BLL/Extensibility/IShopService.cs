using System;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Repository;

namespace ECommerce.BLL.Extensibility
{
    public interface IShopService : IDisposable
    {
        ICategoryRepository<CategoryDto> Categories { get; }

        IProductRepository<ProductDto> Products { get; }

        IOrderRepository<OrderDto> Orders { get; }

        IOrderLineRepository<OrderLineDto> OrderLines { get; }

        int Save();
    }
}
