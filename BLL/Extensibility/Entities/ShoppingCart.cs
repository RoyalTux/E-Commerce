using System.Collections.Generic;

namespace ECommerce.BLL.Extensibility.Entities
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.Lines = new List<ShoppingCartLine>();
        }

        public List<ShoppingCartLine> Lines { get; set; }

        public decimal OverallPrice { get; set; }
    }
}
