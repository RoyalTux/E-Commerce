using System.Data.Entity;
using ECommerce.Core.Extensibility;
using ECommerce.DLL.Extensibility;

namespace ECommerce.DLL
{
    internal class DatabaseSampleDataInitializer : IInitializer
    {
        public void Init()
        {
            Database.SetInitializer(new ShopDbInitializer());
        }
    }
}
