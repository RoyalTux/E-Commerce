using BLL.Extensibility.Dto;

namespace BLL.Extensibility
{
    public interface IManageService
    {
        bool UpdateOrder(OrderDto order);

        OrderDto GetOrder(int id);
    }
}
