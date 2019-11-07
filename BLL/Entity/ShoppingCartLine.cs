using BLL.Extensibility.Dto;

namespace BLL.Entity
{
    internal class ShoppingCartLine
    {
        public int Id { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
    }
}
