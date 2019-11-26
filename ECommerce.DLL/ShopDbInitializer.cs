using System.Collections.Generic;
using System.Data.Entity;
using ECommerce.DLL.Context;
using ECommerce.DLL.DataEntities;

// ReSharper disable CollectionNeverQueried.Local
// ReSharper disable RedundantCommaInInitializer
// ReSharper disable StringLiteralTypo
namespace ECommerce.DLL
{
    public class ShopDbInitializer : DropCreateDatabaseAlways<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            IList<CategoryDataEntity> categories = new List<CategoryDataEntity>();
            var categoryDance = new CategoryDataEntity()
            {
                Name = "Dance",
            };

            var categoryTrance = new CategoryDataEntity()
            {
                Name = "Trance",
            };

            var categoryClassic = new CategoryDataEntity()
            {
                Name = "Classic",
            };

            categories.Add(categoryDance);
            categories.Add(categoryTrance);
            categories.Add(categoryClassic);

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }


            IList<ProductDataEntity> products = new List<ProductDataEntity>()
            {

                CreateTranceMusicProduct(categoryTrance),
                CreateClassicMusicProduct(categoryClassic),
            };

            foreach (ProductDataEntity product in products)
            {
                context.Product.Add(product);
            }

            base.Seed(context);
        }

        private static ProductDataEntity CreateTranceMusicProduct(CategoryDataEntity categoryTrance)
        {
            return new ProductDataEntity()
            {
                Name = "DJ Mix Number 05",
                Album = "Frankenthal (Pfalz) / Germany",
                Artist = "Boris Brejcha ",
                Description = "Original Mix",
                PhotoPath = "https://image.shutterstock.com/image-vector/music-note-design-element-doodle-260nw-616470641.jpg",
                Price = 20,
                Quantity = 3,
                TrackDuration = 2.5,
                CategoryDataEntity = categoryTrance,
            };
        }

        private static ProductDataEntity CreateClassicMusicProduct(CategoryDataEntity categoryClassic)
        {
            return new ProductDataEntity()
            {
                Name = "DJ Mix Number 06",
                Album = "Frankenthal (Pfalz) / Germany",
                Artist = "Boris Brejcha ",
                Description = "Original Mix",
                PhotoPath = "https://image.shutterstock.com/image-vector/music-note-design-element-doodle-260nw-616470641.jpg",
                Price = 30,
                Quantity = 2,
                TrackDuration = 1.5,
                CategoryDataEntity = categoryClassic
            };
        }
    }
}
