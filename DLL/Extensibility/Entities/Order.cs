using System;
using System.Collections.Generic;

namespace DLL.Extensibility.Entities
{
    public enum State
    {
        Confirmed,
        InProcess,
        Declined,
    }

    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public State State { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}