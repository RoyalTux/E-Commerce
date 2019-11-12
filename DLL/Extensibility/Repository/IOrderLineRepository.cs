using DLL.Extensibility.Entities;

namespace DLL.Extensibility.Repository
{
    public interface IOrderLineRepository : IBaseRepository<OrderLine>
    {
        OrderLine GetById(int id);
    }
}
