using System.Collections.Generic;

namespace ECommerce.DLL.Extensibility.Entities
{
    public class Cart
    {
        public Cart()
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
