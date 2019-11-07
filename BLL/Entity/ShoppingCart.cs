using System.Collections.Generic;
using BLL.Extensibility;

namespace BLL.Entity
{
    internal class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.Lines = new List<Extensibility.Entity.ShoppingCartLine>();
        }

        public List<Extensibility.Entity.ShoppingCartLine> Lines { get; set; }

        public decimal OverallPrice { get; set; }
    }
}
