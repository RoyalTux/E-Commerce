using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebAPI.Models
{
    public class OrderView
    {
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public double TimeInMilliseconds => this.Time.Subtract(new DateTime(1970, 1, 1)).Milliseconds;

        [Required]
        public double Price { get; set; }

        public string Name { get; set; }

        public ICollection<OrderLineView> OrderLines { get; set; }

        public UserProfileView UserProfile { get; set; }
    }
}