using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    internal class CartBuilder
    {
        public static void BuildCart(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CartDataEntity>()
                .Property(x => x.TrackingNumber)
                .IsRequired();

            modelBuilder.Entity<CartDataEntity>()
                .HasMany(x => x.OrderDataEntities);
        }
    }
}
