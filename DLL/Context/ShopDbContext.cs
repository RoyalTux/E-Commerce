using System.Data.Entity;
using ECommerce.DLL.Extensibility;
using ECommerce.DLL.Extensibility.Entities;
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

        public IDbSet<UserProfile> UserProfiles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Product { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CategoryBuilder.BuildCategory(modelBuilder);
            OrderBuilder.BuildOrder(modelBuilder);
            OrderLineBuilder.BuildOrderLine(modelBuilder);
            ProductBuilder.BuildProduct(modelBuilder);
            UserProfileBuilder.BuildUserProfile(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
