using System;
using System.Collections.Generic;

namespace BLL.Extensibility.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            this.Products = new List<ProductDto>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public StateDto State { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}
