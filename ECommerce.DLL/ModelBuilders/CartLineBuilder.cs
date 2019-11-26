using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class CartLineBuilder
    {
        public static void BuildCartLine(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CartLineDataEntity>()
                .ToTable("CartLine")
                .HasKey(x => x.Id);

            modelBuilder.Entity<CartLineDataEntity>()
                .ToTable("CartLine")
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<CartLineDataEntity>()
                .ToTable("CartLine")
                .HasRequired(x => x.Product);
        }
    }
}
