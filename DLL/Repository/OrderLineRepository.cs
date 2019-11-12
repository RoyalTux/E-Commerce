using System.Linq;
using AutoMapper;
using DLL.Extensibility;
using DLL.Extensibility.Entities;
using DLL.Extensibility.Repository;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace DLL.Repository
{
    internal class OrderLineRepository : BaseRepository<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public OrderLine GetById(int id)
        {
            var entity = this.Mapper.Map<OrderLine>(this.Set.Where(x => x.Id == id).FirstOrDefault());

            return entity;
        }
    }
}
