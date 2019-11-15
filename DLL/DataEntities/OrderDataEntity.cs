using System;
using System.Collections.Generic;

namespace ECommerce.DLL.DataEntities
{
    internal class OrderDataEntity
    {
        public OrderDataEntity()
        {
            this.Products = new List<ProductDataEntity>();
            this.OrderLines = new List<OrderLineDataEntity>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public OrderStateDataEntity StateDataEntity { get; set; }

        public int? OrderLineId { get; set; }

        public List<ProductDataEntity> Products { get; set; }

        public ICollection<OrderLineDataEntity> OrderLines { get; set; }
    }
}
