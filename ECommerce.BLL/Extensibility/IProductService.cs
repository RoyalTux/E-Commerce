using System.Collections.Generic;
using ECommerce.BLL.Extensibility.Dto;

namespace ECommerce.BLL.Extensibility
{
    public interface IProductService
    {
        ProductDto GetProduct(int id);

        IEnumerable<ProductDto> GetAllProducts();

        IEnumerable<ProductDto> GetProductsWithPagination(int page, int pageSize);

        IEnumerable<ProductDto> SearchProduct(string request);

        IEnumerable<ProductDto> FilterProductByCategory(int categoryId);
    }
}
