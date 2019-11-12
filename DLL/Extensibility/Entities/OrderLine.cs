namespace DLL.Extensibility.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
    }
}
