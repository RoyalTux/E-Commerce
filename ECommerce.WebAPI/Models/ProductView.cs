using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebAPI.Models
{
    public class ProductView
    {
        public ProductView()
        {
            this.Orders = new List<OrderView>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "Invalid product name length")]
        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public string Album { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "Invalid product name length")]
        public string Artist { get; set; }

        public double TrackDuration { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 30, ErrorMessage = "Invalid product description length")]
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