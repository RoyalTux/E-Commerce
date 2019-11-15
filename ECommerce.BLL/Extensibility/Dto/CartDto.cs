using System.Collections.Generic;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility.Dto
{
    public class CartDto
    {
        public CartDto()
        {
            this.Carts = new List<Cart>();
        }

        public int Id { get; set; }

        public int TrackingNumber { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
