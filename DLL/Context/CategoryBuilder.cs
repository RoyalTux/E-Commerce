using System.Data.Entity;
using Category = DLL.Extensibility.Entities.Category;

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
        }
    }
}
