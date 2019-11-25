using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class CartBuilder
    {
        public static void BuildCart(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CartDataEntity>()
                .HasMany(x => x.CartLineDataEntities);

            modelBuilder.Entity<CartDataEntity>()
                .HasRequired(x => x.UserProfile);
        }
    }
}
