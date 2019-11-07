using DLL.Extensibility.Entities;

namespace DLL.Extensibility.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Order GetById(int id);
    }
}
