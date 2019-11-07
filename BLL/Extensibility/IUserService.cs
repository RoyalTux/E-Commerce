using BLL.Extensibility.Dto;

namespace BLL.Extensibility
{
    public interface IUserService
    {
        bool AddProduct(ProductDto item, int quantity, IShoppingCart lineCollection);

        bool RemoveProduct(ProductDto item, IShoppingCart lineCollection);

        bool Clear(IShoppingCart lineCollection);

        IShoppingCart ComposeCart(IShoppingCart lineCollection);

        OrderDto MakeOrder(IShoppingCart cart);
    }
}
