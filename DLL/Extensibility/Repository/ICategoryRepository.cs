using ECommerce.DLL.Extensibility.Entities;

// ReSharper disable once UnusedMember.Global
namespace ECommerce.DLL.Extensibility.Repository
{
    public interface ICategoryRepository<TDataEntity> : IBaseRepository<Category>
        where TDataEntity : class
    {
        TDataEntity GetById(int id);
    }
}
