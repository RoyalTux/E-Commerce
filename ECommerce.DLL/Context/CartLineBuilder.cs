using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class CartLineBuilder
    {
        public static void BuildCartLine(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartLineDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CartLineDataEntity>()
                .Property(x => x.Quantity)
                .IsRequired();

            modelBuilder.Entity<CartLineDataEntity>()
                .HasRequired(x => x.Product);
        }
    }
}
