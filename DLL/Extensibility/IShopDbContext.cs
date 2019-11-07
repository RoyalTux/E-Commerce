using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DLL.Extensibility.Entities;

// ReSharper disable UnusedMember.Global
namespace DLL.Extensibility
{
    public interface IShopDbContext
    {
        IDbSet<UserProfile> UserProfiles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Product> Product { get; set; }

        IDbSet<Order> Orders { get; set; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
