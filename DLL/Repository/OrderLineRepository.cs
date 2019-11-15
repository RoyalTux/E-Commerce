using AutoMapper;
using ECommerce.DLL.DataEntities;
using ECommerce.DLL.Extensibility;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace ECommerce.DLL.Repository
{
    internal class OrderLineRepository : BaseRepository<OrderLine, OrderLineDataEntity>, IOrderLineRepository<OrderLineDataEntity>
    {
        public OrderLineRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
