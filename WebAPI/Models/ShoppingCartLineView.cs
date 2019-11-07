namespace WebAPI.Models
{
    public class ShoppingCartLineView
    {
        public int ShoppingCartId { get; set; }

        public ProductView Item { get; set; }

        public int Quantity { get; set; }
    }
}