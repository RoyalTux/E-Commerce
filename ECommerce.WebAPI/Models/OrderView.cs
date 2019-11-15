using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebAPI.Models
{
    public class OrderView
    {
        public OrderView()
        {
            this.Products = new List<ProductView>();
        }

        public int OrderId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public double TimeInMilliseconds => this.Time.Subtract(new DateTime(1970, 1, 1)).Milliseconds;

        [Required]
        public double Price { get; set; }

        [Required]
        public StateView State { get; set; }

        public ICollection<ProductView> Products { get; set; }
    }
}