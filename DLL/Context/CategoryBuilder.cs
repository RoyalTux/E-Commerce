using System.Data.Entity;
using DLL.Extensibility.Entities;

namespace DLL.Context
{
    internal class CategoryBuilder
    {
        public static void BuildCategory(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(x => x.SubCategories)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
