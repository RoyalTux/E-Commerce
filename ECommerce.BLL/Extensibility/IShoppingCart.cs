using System.Collections.Generic;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility
{
    public interface IShoppingCart
    {
        List<Product> Products { get; set; }

        decimal OverallPrice { get; set; }

        int TrackingNumber { get; set; }

        int Quantity { get; set; }
    }
}
