using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;

namespace ECommerce.BLL.Extensibility
{
    public interface ICartService
    {
        bool Clear(ICartLineService lineCollection);

        CartDto ComposeCart(ICartLineService lineCollection);

        decimal OverallPrice { get; set; }

        UserProfile User { get; set; }
    }
}
