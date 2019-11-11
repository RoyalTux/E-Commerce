using System.Data.Entity;
using System.Linq;
using AutoMapper;
using DLL.Extensibility;
using DLL.Extensibility.Repository;
using SubCategory = DLL.Extensibility.Entities.SubCategory;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
namespace DLL.Repository
{
    internal class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(IShopDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public SubCategory GetById(int id)
        {
            var entity = this.Mapper.Map<SubCategory>(this.Set.Include(x => x.Products).Where(x => x.Id == id).FirstOrDefault());

            return entity;
        }
    }
}
