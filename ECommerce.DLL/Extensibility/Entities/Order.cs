using System;
using System.Collections.Generic;

namespace ECommerce.DLL.Extensibility.Entities
{
    public class Order
    {
        public Order()
        {
            this.OrderLines = new List<OrderLine>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}