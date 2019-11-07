using BLL.Extensibility;
using BLL.Extensibility.Entity;
using Ninject.Modules;

namespace WebAPI.Infrastructure
{
    public class WebApiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
        }
    }
}