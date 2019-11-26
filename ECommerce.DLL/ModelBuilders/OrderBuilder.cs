using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class OrderBuilder
    {
        public static void BuildOrder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<OrderDataEntity>()
                .ToTable("Order")
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderDataEntity>()
                .ToTable("Order")
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<OrderDataEntity>()
                .ToTable("Order")
                .Property(x => x.Time)
                .IsRequired();

            modelBuilder.Entity<OrderDataEntity>()
                .ToTable("Order")
                .HasRequired(x => x.UserProfile);

            modelBuilder.Entity<OrderDataEntity>()
                .ToTable("Order")
                .HasMany(x => x.OrderLines);
        }
    }
}