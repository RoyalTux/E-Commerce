using ECommerce.Core.Extensibility;
using ECommerce.DLL.Context;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo
namespace ECommerce.DLL.Extensibility.Infrastructure
{
    public class DLLNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(r => r.FromThisAssembly()
                .IncludingNonePublicTypes()
                .Select(t => t.Name.EndsWith("Repository"))
                .BindAllInterfaces());

            this.Bind<IShopDbContext>().To<ShopDbContext>().InRequestScope();
            this.Bind<IInitializer>().To<DatabaseSampleDataInitializer>();
        }
    }
}
