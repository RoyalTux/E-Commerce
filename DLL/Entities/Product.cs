namespace DLL.Entities
{
    internal class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public double TrackDuration { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
