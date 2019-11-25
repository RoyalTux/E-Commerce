namespace ECommerce.WebAPI.Models
{
    public class OrderLineView
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public double TrackDuration { get; set; }

        public ProductView Product { get; set; }

        public virtual OrderView Order { get; set; }
    }
}