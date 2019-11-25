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
            this.Bind<IRepositoryBase<Cart>>().To<RepositoryBase<Cart, CartDataEntity>>();
            this.Bind<IRepositoryBase<CartLine>>().To<RepositoryBase<CartLine, CartLineDataEntity>>();
            this.Bind<IRepositoryBase<Category>>().To<RepositoryBase<Category, CategoryDataEntity>>();
            this.Bind<IRepositoryBase<Order>>().To<RepositoryBase<Order, OrderDataEntity>>();
            this.Bind<IRepositoryBase<OrderLine>>().To<RepositoryBase<OrderLine, OrderLineDataEntity>>();
            this.Bind<IRepositoryBase<UserProfile>>().To<RepositoryBase<UserProfile, UserProfileDataEntity>>();
        }
    }
}
