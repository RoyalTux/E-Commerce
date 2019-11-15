using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.DLL.Extensibility.Repository
{
    public interface IProductRepository<TDataEntity> : IBaseRepository<Product>
        where TDataEntity : class
    {
        TDataEntity GetById(int id);
    }
}
