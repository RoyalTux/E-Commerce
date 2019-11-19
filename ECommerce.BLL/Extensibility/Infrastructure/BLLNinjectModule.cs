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

            this.Bind<IProductService>().To<ProductService>();
        }
    }
}