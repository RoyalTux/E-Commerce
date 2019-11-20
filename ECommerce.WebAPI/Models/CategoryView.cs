using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebAPI.Models
{
    public class CategoryView
    {
        public CategoryView()
        {
            this.Products = new List<ProductView>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "Invalid category name length")]
        public string Name { get; set; }

        public ICollection<ProductView> Products { get; set; }

    }
}