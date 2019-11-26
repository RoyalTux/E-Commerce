using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class CartBuilder
    {
        public static void BuildCart(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CartDataEntity>()
                .ToTable("Cart")
                .HasKey(x => x.Id);

            modelBuilder.Entity<CartDataEntity>()
                .ToTable("Cart")
                .HasMany(x => x.CartLineDataEntities);

            modelBuilder.Entity<CartDataEntity>()
                .ToTable("Cart")
                .HasRequired(x => x.UserProfile);
        }
    }
}
