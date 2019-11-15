using System.Collections.Generic;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Entities;

namespace ECommerce.BLL.DataEntities
{
    internal class ShoppingCartDataEntity : IShoppingCart
    {
        public ShoppingCartDataEntity()
        {
            this.Lines = new List<ShoppingCartLine>();
        }

        public List<ShoppingCartLine> Lines { get; set; }

        public decimal OverallPrice { get; set; }
    }
}
