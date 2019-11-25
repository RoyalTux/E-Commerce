namespace ECommerce.DLL.Extensibility.Entities
{
    public class CartLine
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
