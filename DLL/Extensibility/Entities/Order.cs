using System;
using System.Collections.Generic;

namespace DLL.Extensibility.Entities
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public OrderState State { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}