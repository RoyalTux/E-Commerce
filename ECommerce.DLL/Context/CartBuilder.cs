using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class CartBuilder
    {
        public static void BuildCart(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CartDataEntity>()
                .Property(x => x.TrackingNumber)
                .IsRequired();

            modelBuilder.Entity<CartDataEntity>()
                .Property(x => x.OverallPrice)
                .IsRequired();

            modelBuilder.Entity<CartDataEntity>()
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<CartDataEntity>()
                .HasMany(x => x.ProductDataEntities);
        }
    }
}
