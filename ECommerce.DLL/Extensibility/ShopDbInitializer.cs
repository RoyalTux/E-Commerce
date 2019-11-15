using System.Collections.Generic;
using System.Data.Entity;
using ECommerce.DLL.Context;
using ECommerce.DLL.Extensibility.Entities;

// ReSharper disable CollectionNeverQueried.Local
// ReSharper disable RedundantCommaInInitializer
// ReSharper disable StringLiteralTypo
namespace ECommerce.DLL.Extensibility
{
    public class ShopDbInitializer : CreateDatabaseIfNotExists<ShopDbContext>
    {
        public IList<Entities.UserProfile> SeedUserProfiles()
        {
            IList<UserProfile> profiles = new List<UserProfile>();

            profiles.Add(new UserProfile()
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                Password = "123456789",
                Name = "admin",
                Address = "cvetochnaya 1b",
                Role = "admin",
            });

            profiles.Add(new UserProfile()
            {
                Email = "manager@gmail.com",
                UserName = "manager@gmail.com",
                Password = "123456789",
                Name = "manager",
                Address = "sadovaya 3a",
                Role = "manager",
            });

            profiles.Add(new UserProfile()
            {
                Email = "user@gmail.com",
                UserName = "user@gmail.com",
                Password = "123456789",
                Name = "user",
                Address = "visnevaya 3c",
                Role = "user",
            });

            return profiles;
        }

        public IList<Product> SeedProducts()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product()
            {
                Name = "DJ Mix Number 05",
                Album = "Frankenthal (Pfalz) / Germany",
                Artist = "Boris Brejcha ",
                Description = "Original Mix",
                PhotoPath = "https://image.shutterstock.com/image-vector/music-note-design-element-doodle-260nw-616470641.jpg",
                Price = 20,
                Quantity = 3,
                TrackDuration = 2.5,
            });

            products.Add(new Product()
            {
                Name = "DJ Mix Number 06",
                Album = "Frankenthal (Pfalz) / Germany",
                Artist = "Boris Brejcha ",
                Description = "Original Mix",
                PhotoPath = "https://image.shutterstock.com/image-vector/music-note-design-element-doodle-260nw-616470641.jpg",
                Price = 30,
                Quantity = 2,
                TrackDuration = 1.5,
            });

            products.Add(new Product()
            {
                Name = "DJ Mix Number 07",
                Album = "Frankenthal (Pfalz) / Germany",
                Artist = "Boris Brejcha ",
                Description = "Original Mix",
                PhotoPath = "https://image.shutterstock.com/image-vector/music-note-design-element-doodle-260nw-616470641.jpg",
                Price = 10,
                Quantity = 4,
                TrackDuration = 5.5,
            });

            return products;
        }

        protected override void Seed(ShopDbContext context)
        {
            this.SeedUserProfiles();
            this.SeedProducts();

            base.Seed(context);
        }
    }
}
