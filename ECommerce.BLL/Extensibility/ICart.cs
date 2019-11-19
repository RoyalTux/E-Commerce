using System.Collections.Generic;
using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility
{
    public interface ICart
    {
        List<OrderDto> Orders { get; set; }

        decimal OverallPrice { get; set; }
    }
}
