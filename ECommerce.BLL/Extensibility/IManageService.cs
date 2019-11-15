using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility
{
    public interface IManageService
    {
        bool UpdateOrder(OrderDto order);

        OrderDto GetOrder(int id);
    }
}
