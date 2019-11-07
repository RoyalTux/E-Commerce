using BLL.Extensibility.Dto;

namespace BLL.Extensibility
{
    public interface IAdminService
    {
        bool AddCategory(CategoryDto categoryDto);

        bool UpdateCategory(CategoryDto categoryDto);

        bool RemoveCategory(int id);

        bool AddProduct(ProductDto itemDto);

        bool UpdateProduct(ProductDto itemDto);

        bool RemoveProduct(int id);

        CategoryDto GetCategory(int id);

        ProductDto GetProduct(int id);

        OrderDto GetOrder(int id);

        void Dispose(bool disposing);
    }
}
