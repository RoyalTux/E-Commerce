using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility
{
    public interface IOrderService
    {
        OrderDto MakeOrder(ICartLineService cart);

        bool UpdateOrder(OrderDto order);

        OrderDto GetOrder(int id);
    }
}
