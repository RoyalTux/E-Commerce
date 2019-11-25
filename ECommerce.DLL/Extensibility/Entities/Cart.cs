using System.Collections.Generic;

namespace ECommerce.DLL.Extensibility.Entities
{
    public class Cart
    {
        public Cart()
        {
            this.CartLines = new List<CartLine>();
        }

        public int Id { get; set; }

        public ICollection<CartLine> CartLines { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
