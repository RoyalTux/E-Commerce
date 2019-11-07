using DLL.Extensibility.Entities;

namespace DLL.Extensibility.Repository
{
    public interface IItemRepository : IBaseRepository<Product>
    {
        Product GetById(int id);
    }
}
