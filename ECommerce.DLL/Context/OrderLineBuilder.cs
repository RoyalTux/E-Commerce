using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class OrderLineBuilder
    {
        public static void BuildOrderLine(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLineDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.Album)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.Artist)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.Description)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.PhotoPath)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .Property(x => x.TrackDuration)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .HasRequired(x => x.OrderDataEntity);

            modelBuilder.Entity<OrderLineDataEntity>()
                .HasRequired(x => x.ProductDataEntity);
        }
    }
}
