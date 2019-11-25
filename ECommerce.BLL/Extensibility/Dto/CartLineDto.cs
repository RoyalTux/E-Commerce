using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility.Dto
{
    public class CartLineDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
