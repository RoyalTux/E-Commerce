using System.Collections.Generic;

namespace ECommerce.DLL.Extensibility.Entities
{
    public class Cart
    {
        public Cart()
        {
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
