using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility
{
    public interface IUserService
    {
        bool AddProduct(ProductDto product, int quantity, IShoppingCart lineCollection);

        bool RemoveProduct(ProductDto product, IShoppingCart lineCollection);

        bool Clear(IShoppingCart lineCollection);

        IShoppingCart ComposeCart(IShoppingCart lineCollection);

        OrderDto MakeOrder(IShoppingCart cart);
    }
}
