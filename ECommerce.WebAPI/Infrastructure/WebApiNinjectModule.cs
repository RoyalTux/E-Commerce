using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Entities;
using Ninject.Modules;

namespace ECommerce.WebAPI.Infrastructure
{
    public class WebApiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
        }
    }
}