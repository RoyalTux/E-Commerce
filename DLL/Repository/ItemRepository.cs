using System.Linq;
using AutoMapper;
using DLL.Extensibility;
using DLL.Extensibility.Entities;
using DLL.Extensibility.Repository;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace DLL.Repository
{
    internal class ItemRepository : BaseRepository<Product>, IItemRepository
    {
        public ItemRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public Product GetById(int id)
        {
            var entity = this.Mapper.Map<Product>(this.Set.Where(x => x.Id == id).FirstOrDefault());
            return entity;
        }
    }
}
