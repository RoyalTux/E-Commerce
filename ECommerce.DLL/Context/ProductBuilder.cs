using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class ProductBuilder
    {
        public static void BuildProduct(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.Description)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.PhotoPath)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.Album)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.Artist)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .Property(x => x.TrackDuration)
                .IsRequired();

            modelBuilder.Entity<ProductDataEntity>()
                .HasRequired(x => x.CategoryDataEntity);
        }
    }
}