using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ECommerce.DLL.Extensibility.Entities;

// ReSharper disable UnusedMember.Global
namespace ECommerce.DLL.Extensibility
{
    public interface IShopDbContext
    {
        IDbSet<UserProfile> UserProfiles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Product> Product { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<OrderLine> OrderLines { get; set; }

        DbSet<TDataEntity> Set<TDataEntity>()
            where TDataEntity : class;

        DbEntityEntry<TDataEntity> Entry<TDataEntity>(TDataEntity entity)
            where TDataEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
