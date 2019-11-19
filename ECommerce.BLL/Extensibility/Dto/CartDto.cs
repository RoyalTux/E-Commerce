using System.Collections.Generic;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility.Dto
{
    public class CartDto
    {
        public CartDto()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public int TrackingNumber { get; set; }

        public decimal OverallPrice { get; set; }

        public int Quantity { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
