using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility.Dto
{
    public class OrderLineDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
    }
}
