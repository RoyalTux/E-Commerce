using AutoMapper;
using ECommerce.DLL.DataEntities;
using ECommerce.DLL.Extensibility;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace ECommerce.DLL.Repository
{
    internal class OrderRepository : BaseRepository<Order, OrderDataEntity>, IOrderRepository<OrderDataEntity>
    {
        public OrderRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
