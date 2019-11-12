using System.Collections.Generic;
using DLL.Extensibility.Entities;

namespace BLL.Extensibility.Dto
{
    public class SubCategoryDto
    {
        public SubCategoryDto()
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
