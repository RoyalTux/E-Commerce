using BLL.Extensibility.Dto;

namespace BLL.Extensibility.Entity
{
    public class ShoppingCartLine
    {
        public int Id { get; set; }

        public ProductDto Item { get; set; }

        public int Quantity { get; set; }
    }
}
