using System.Collections.Generic;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility
{
    public interface IShoppingCartService
    {
        List<Product> Products { get; set; }

        int Quantity { get; set; }
    }
}
