using System.Collections.Generic;

namespace ECommerce.DLL.DataEntities
{
    public class CartDataEntity
    {
        public CartDataEntity()
        {
            this.ProductDataEntities = new List<ProductDataEntity>();
        }

        public int Id { get; set; }

        public int TrackingNumber { get; set; }

        public decimal OverallPrice { get; set; }

        public int Quantity { get; set; }

        public ICollection<ProductDataEntity> ProductDataEntities { get; set; }
    }
}
