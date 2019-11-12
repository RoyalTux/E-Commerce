using DLL.Extensibility.Entities;

namespace BLL.Extensibility.Dto
{
    public class OrderLineDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
    }
}
