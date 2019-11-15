using System.Collections.Generic;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Infrastructure;

namespace ECommerce.BLL.Extensibility
{
    public interface IProductService
    {
        ProductDto GetProduct(int id);

        IEnumerable<ProductDto> GetAllProducts();

        IEnumerable<ProductDto> GetProductsWithPagination(int page, int pageSize);

        IEnumerable<ProductDto> SortBy(BLLSortCriteria sortParam);

        IEnumerable<ProductDto> SortByDescending(BLLSortCriteria sortParam);

        IEnumerable<ProductDto> Search(string request);

        // IEnumerable<ProductDto> FilterByCategory(int categoryId);
    }
}
