using System.Data.Entity;
using DLL.Extensibility.Entities;

namespace DLL.Context
{
    internal class ProductBuilder
    {
        public static void BuildProduct(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.PhotoPath)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Quantity)
                .IsRequired();
        }
    }
}