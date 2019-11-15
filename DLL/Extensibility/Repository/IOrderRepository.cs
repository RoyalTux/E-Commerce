using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.DLL.Extensibility.Repository
{
    public interface IOrderRepository<TDataEntity> : IBaseRepository<Order>
        where TDataEntity : class
    {
        TDataEntity GetById(int id);
    }
}
