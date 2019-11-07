using System.Data.Entity;
using Core.Extensibility;
using DLL.Context;
using DLL.Extensibility;

namespace Core
{
	public class DatabaseSampleDataInitializer : IInitializer
	{
		public void Init()
		{
			Database.SetInitializer(new ShopDbInitializer());
		}
	}
}
