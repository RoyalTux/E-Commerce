using System.Data.Entity;
using System.Linq;
using AutoMapper;
using DLL.Extensibility;
using DLL.Extensibility.Entities;
using DLL.Extensibility.Repository;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace DLL.Repository
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public Category GetById(int id)
        {
            var entity = this.Mapper.Map<Category>(this.Set.Include(x => x.SubCategories).Where(x => x.Id == id).FirstOrDefault());
            return entity;
        }
    }
}
