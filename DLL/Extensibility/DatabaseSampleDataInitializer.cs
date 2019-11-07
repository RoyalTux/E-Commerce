using System.Data.Entity;
using Core.Extensibility;

namespace DLL.Extensibility
{
    public class DatabaseSampleDataInitializer : IInitializer
    {
        public void Init()
        {
            Database.SetInitializer(new ShopDbInitializer());
        }
    }
}
