using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class OrderLineBuilder
    {
        public static void BuildOrderLine(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.Album)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.Artist)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.Description)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.PhotoPath)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .Property(x => x.TrackDuration)
                .IsRequired();

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .HasRequired(x => x.OrderDataEntity);

            modelBuilder.Entity<OrderLineDataEntity>()
                .ToTable("OrderLine")
                .HasRequired(x => x.ProductDataEntity);
        }
    }
}
