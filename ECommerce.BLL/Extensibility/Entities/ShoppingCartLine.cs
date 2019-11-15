using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility.Entities
{
    public class ShoppingCartLine
    {
        public int Id { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
    }
}
