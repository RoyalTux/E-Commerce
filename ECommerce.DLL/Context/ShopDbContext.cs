using System.Data.Entity;
using ECommerce.DLL.DataEntities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerce.DLL.Context
{
    public class ShopDbContext : IdentityDbContext, IShopDbContext
    {
        public ShopDbContext()
            : base("name=E-CommerceDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<UserProfileDataEntity> UserProfiles { get; set; }

        public IDbSet<CategoryDataEntity> Categories { get; set; }

        public IDbSet<ProductDataEntity> Product { get; set; }

        public IDbSet<OrderDataEntity> Orders { get; set; }

        public IDbSet<OrderLineDataEntity> OrderLines { get; set; }

        public IDbSet<CartDataEntity> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CategoryBuilder.BuildCategory(modelBuilder);
            OrderBuilder.BuildOrder(modelBuilder);
            OrderLineBuilder.BuildOrderLine(modelBuilder);
            CartBuilder.BuildCart(modelBuilder);
            ProductBuilder.BuildProduct(modelBuilder);
            UserProfileBuilder.BuildUserProfile(modelBuilder);
            CartLineBuilder.BuildCartLine(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
