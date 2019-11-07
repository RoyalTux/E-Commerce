using System.Collections.Generic;
using ShoppingCartLine = BLL.Extensibility.Entity.ShoppingCartLine;

namespace BLL.Extensibility
{
    public interface IShoppingCart
    {
        List<ShoppingCartLine> Lines { get; set; }

        decimal OverallPrice { get; set; }
    }
}
