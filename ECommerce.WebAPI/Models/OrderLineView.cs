namespace ECommerce.WebAPI.Models
{
    public class OrderLineView
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual OrderView Order { get; set; }
    }
}