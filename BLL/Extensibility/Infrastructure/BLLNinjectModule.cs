using ECommerce.BLL.Extensibility.Entities;
using ECommerce.BLL.Services;
using Ninject.Modules;

// ReSharper disable InconsistentNaming
namespace ECommerce.BLL.Extensibility.Infrastructure
{
    public class BLLNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserService>().To<UserService>().InSingletonScope();

            this.Bind<IManageService>().To<ManageService>();

            this.Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();

            this.Bind<IProductService>().To<ProductService>();
        }
    }
}