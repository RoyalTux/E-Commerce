using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class CategoryBuilder
    {
        public static void BuildCategory(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CategoryDataEntity>()
                .ToTable("Category")
                .HasKey(x => x.Id);

            modelBuilder.Entity<CategoryDataEntity>()
                .ToTable("Category")
                .HasMany(x => x.SubCategoryDataEntities)
                .WithOptional(x => x.ParentCategoryDataEntity)
                .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<CategoryDataEntity>()
                .ToTable("Category")
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
