using ECommerce.Core.Extensibility;
using ECommerce.DLL.Context;
using ECommerce.DLL.DataEntities;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;
using ECommerce.DLL.Repository;
using Ninject.Modules;
using Ninject.Web.Common;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo
namespace ECommerce.DLL.Infrastructure
{
    public class DLLNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IShopDbContext>().To<ShopDbContext>().InRequestScope();
            this.Bind<IInitializer>().To<DatabaseSampleDataInitializer>();
            this.Bind<IRepositoryBase<Product>>().To<RepositoryBase<Product, ProductDataEntity>>();
            //this.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
        }
    }
}
