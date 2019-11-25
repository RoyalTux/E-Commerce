using System;
using System.Collections.Generic;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility.Dto
{
    public class OrderDto
    {
        public OrderDto()
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
