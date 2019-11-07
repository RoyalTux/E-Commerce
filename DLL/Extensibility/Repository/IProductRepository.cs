using DLL.Extensibility.Entities;

namespace DLL.Extensibility.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetById(int id);
    }
}
