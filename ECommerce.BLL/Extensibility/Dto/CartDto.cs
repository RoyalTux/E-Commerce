using System.Collections.Generic;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility.Dto
{
    public class CartDto
    {
        public CartDto()
        {
            this.CartLines = new List<CartLine>();
        }

        public int Id { get; set; }

        public ICollection<CartLine> CartLines { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
