using System.Data.Entity;
using Order = DLL.Extensibility.Entities.Order;

namespace DLL.Context
{
    internal class OrderBuilder
    {
        public static void BuildOrder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.State)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.Time)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasMany(p => p.Products);
        }
    }
}