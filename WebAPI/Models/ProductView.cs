using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class ProductView
    {
        public ProductView()
        {
            this.Orders = new List<OrderView>();
        }

        public int ItemId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid product name length")]
        public string ItemName { get; set; }

        public string ItemPhotoPath { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 30, ErrorMessage = "Invalid product description length")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Incorrect quantity of goods")]
        public int Quantity { get; set; }

        public int? CategoryId { get; set; }

        public CategoryView Category { get; set; }

        public ICollection<OrderView> Orders { get; set; }
    }
}