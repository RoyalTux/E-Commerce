using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class ProductBuilder
    {
        public static void BuildProduct(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.Description)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.PhotoPath)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.Album)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.Artist)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .Property(x => x.TrackDuration)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .ToTable("Product")
                .HasRequired(x => x.CategoryDataEntity);
        }
    }
}