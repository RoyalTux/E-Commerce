using System;
using System.Collections.Generic;

namespace DLL.Entities
{
    public enum State
    {
        Confirmed,
        InProcess,
        Declined,
    } // вынести в отдельный файл

    internal class Order
    {
        public Order()
        {
            this.Items = new List<Product>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public State State { get; set; }

        public ICollection<Product> Items { get; set; }
    }
}
