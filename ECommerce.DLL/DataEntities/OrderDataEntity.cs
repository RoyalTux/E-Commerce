using System;
using System.Collections.Generic;

namespace ECommerce.DLL.DataEntities
{
    public class OrderDataEntity
    {
        public OrderDataEntity()
        {
            this.OrderLines = new List<OrderLineDataEntity>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderLineDataEntity> OrderLines { get; set; }

        public UserProfileDataEntity UserProfile { get; set; }
    }
}
