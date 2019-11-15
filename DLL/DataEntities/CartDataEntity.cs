using System.Collections.Generic;

namespace ECommerce.DLL.DataEntities
{
    internal class CartDataEntity
    {
        public CartDataEntity()
        {
            this.OrderDataEntities = new List<OrderDataEntity>();
        }

        public int Id { get; set; }

        public ICollection<OrderDataEntity> OrderDataEntities { get; set; }
    }
}
