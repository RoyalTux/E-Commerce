using DLL.Extensibility.Entities;

// ReSharper disable once UnusedMember.Global
namespace DLL.Extensibility.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetById(int id);
    }
}
