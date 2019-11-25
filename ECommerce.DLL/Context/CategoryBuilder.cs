using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class CategoryBuilder
    {
        public static void BuildCategory(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CategoryDataEntity>()
                .HasMany(x => x.SubCategoryDataEntities)
                .WithOptional(x => x.ParentCategoryDataEntity)
                .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<CategoryDataEntity>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
