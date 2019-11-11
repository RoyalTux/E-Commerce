using System.Data.Entity;
using DLL.Extensibility.Entities;

namespace DLL.Context
{
    internal class SubCategoryBuilder
    {
        public static void BuildSubCategory(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<SubCategory>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<SubCategory>()
                .Property(x => x.Description)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<SubCategory>()
                .HasRequired(x => x.Category);

            modelBuilder.Entity<SubCategory>()
                .HasMany(x => x.Products);

            // .WithRequired(x => x.SubCategory)
            // .HasForeignKey(x => x.SubCategory);
        }
    }
}
