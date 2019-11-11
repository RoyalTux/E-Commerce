using DLL.Extensibility.Entities;

namespace DLL.Extensibility.Repository
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory>
    {
        SubCategory GetById(int id);
    }
}
