using System.Collections.Generic;
using ECommerce.BLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility
{
    public interface IShoppingCart
    {
        List<ShoppingCartLine> Lines { get; set; }

        decimal OverallPrice { get; set; }
    }
}
