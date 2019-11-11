using System.Collections.Generic;

namespace DLL.Entities
{
    internal class SubCategory
    {
        public SubCategory()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
