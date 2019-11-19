using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ECommerce.DLL.DataEntities;

// ReSharper disable UnusedMember.Global
namespace ECommerce.DLL.Context
{
    public interface IShopDbContext
    {
        IDbSet<UserProfileDataEntity> UserProfiles { get; set; }

        IDbSet<CategoryDataEntity> Categories { get; set; }

        IDbSet<ProductDataEntity> Product { get; set; }

        IDbSet<OrderDataEntity> Orders { get; set; }

        IDbSet<OrderLineDataEntity> OrderLines { get; set; }

        IDbSet<CartDataEntity> Carts { get; set; }

        DbSet<TDataEntity> Set<TDataEntity>()
            where TDataEntity : class;

        DbEntityEntry<TDataEntity> Entry<TDataEntity>(TDataEntity entity)
            where TDataEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
