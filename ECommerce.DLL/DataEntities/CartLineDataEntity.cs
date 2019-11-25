namespace ECommerce.DLL.DataEntities
{
    public class CartLineDataEntity
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public ProductDataEntity Product { get; set; }
    }
}
