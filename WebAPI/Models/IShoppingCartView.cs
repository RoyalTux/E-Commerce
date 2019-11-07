using System.Collections.Generic;

namespace WebAPI.Models
{
    public interface IShoppingCartView
    {
        List<ShoppingCartLineView> Lines { get; set; }

        double OverallPrice { get; set; }
    }
}