using System.Collections.Generic;

namespace BLL.Extensibility.Entity
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
