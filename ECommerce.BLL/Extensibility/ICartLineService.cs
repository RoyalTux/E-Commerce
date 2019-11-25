using System.Collections.Generic;
using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility
{
    public interface ICartLineService
    {
        List<ProductDto> Products { get; set; }

        bool AddProduct(ProductDto product, int quantity, ICartLineService lineCollection);

        bool RemoveProduct(ProductDto product, ICartLineService lineCollection);
    }
}
