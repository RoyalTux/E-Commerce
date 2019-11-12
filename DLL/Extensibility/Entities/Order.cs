using System;
using System.Collections.Generic;

namespace DLL.Extensibility.Entities
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
            this.OrderLines = new List<OrderLine>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public OrderState State { get; set; }

        public int? OrderLineId { get; set; }

        public List<Product> Products { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}