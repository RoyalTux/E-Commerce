using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.DataEntities
{
    internal class ShoppingCartLineDataEntity
    {
        public int Id { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
    }
}
