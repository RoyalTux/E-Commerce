using BLL.Extensibility.Dto;

namespace BLL.Extensibility
{
    public interface IUserService
    {
        bool AddItem(ProductDto item, int quantity, IShoppingCart lineCollection);

        bool RemoveItem(ProductDto item, IShoppingCart lineCollection);

        bool Clear(IShoppingCart lineCollection);

        IShoppingCart ComposeCart(IShoppingCart lineCollection);

        OrderDto MakeOrder(IShoppingCart cart);
    }
}
