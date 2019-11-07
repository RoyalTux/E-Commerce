using System;
using System.Data.Entity;
using DLL.Extensibility;
using DLL.Extensibility.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DLL.Context
{
    public class ShopDbContext : IdentityDbContext, IShopDbContext
    {
        public ShopDbContext()
            : base("name=E-CommerceDbContext")
        {
        }

        public IDbSet<UserProfile> UserProfiles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Items { get; set; }

        public IDbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            CategoryBuilder.BuildCategory(modelBuilder);
            OrderBuilder.BuildOrder(modelBuilder);
            ProductBuilder.BuildProduct(modelBuilder);
            UserProfileBuilder.BuildUserProfile(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
