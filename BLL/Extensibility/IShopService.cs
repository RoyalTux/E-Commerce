using System;
using DLL.Extensibility.Repository;

namespace BLL.Extensibility
{
    public interface IShopService : IDisposable
    {
        ICategoryRepository Categories { get; }

        ISubCategoryRepository SubCategories { get; }

        IProductRepository Products { get; }

        IOrderRepository Orders { get; }

        IOrderLineRepository OrderLines { get; }

        int Save();
    }
}
