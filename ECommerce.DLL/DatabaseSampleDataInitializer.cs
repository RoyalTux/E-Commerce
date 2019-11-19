using System.Data.Entity;
using ECommerce.Core.Extensibility;

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
