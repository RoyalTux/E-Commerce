using System.Collections.Generic;
using System.Data.Entity;
using DLL.Context;
using DLL.Entities;

namespace DLL.Extensibility
{
    public class ShopDbInitializer : CreateDatabaseIfNotExists<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            IList<UserProfile> defaultStandards = new List<UserProfile>();

            defaultStandards.Add(new UserProfile()
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                Password = "123456789",
                Name = "admin",
                Address = "cvetochnaya 1b",
                Role = "admin",
            });

            defaultStandards.Add(new UserProfile()
            {
                Email = "manager@gmail.com",
                UserName = "manager@gmail.com",
                Password = "123456789",
                Name = "manager",
                Address = "sadovaya 3a",
                Role = "manager",
            });

            defaultStandards.Add(new UserProfile()
            {
                Email = "user@gmail.com",
                UserName = "user@gmail.com",
                Password = "123456789",
                Name = "user",
                Address = "visnevaya 3c",
                Role = "user",
            });

            base.Seed(context);
        }
    }
}
