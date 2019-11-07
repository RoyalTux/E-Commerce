using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CategoryView
    {
        public CategoryView()
        {
            this.Items = new List<ProductView>();
        }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid category name length")]
        public string CategoryName { get; set; }

        public ICollection<ProductView> Items { get; set; }
    }
}