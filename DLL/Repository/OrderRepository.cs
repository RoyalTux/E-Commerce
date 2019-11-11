using System.Data.Entity;
using System.Linq;
using AutoMapper;
using DLL.Extensibility;
using DLL.Extensibility.Entities;
using DLL.Extensibility.Repository;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace DLL.Repository
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public Order GetById(int id)
        {
            var entity = this.Mapper.Map<Order>(this.Set.Include(x => x.Products).Where(x => x.Id == id).FirstOrDefault());

            return entity;
        }
    }
}
