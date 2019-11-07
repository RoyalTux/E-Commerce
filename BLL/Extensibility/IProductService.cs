using System.Collections.Generic;
using BLL.Extensibility.Dto;
using BLL.Extensibility.Infrastructure;

namespace BLL.Extensibility
{
    public interface IProductService
    {
        ProductDto GetProduct(int id);

        IEnumerable<ProductDto> GetAllProducts();

        IEnumerable<ProductDto> GetProductsWithPagination(int page, int pageSize);

        IEnumerable<ProductDto> SortBy(BLLSortCriteria sortParam);

        IEnumerable<ProductDto> SortByDescending(BLLSortCriteria sortParam);

        IEnumerable<ProductDto> Search(string request);

        IEnumerable<ProductDto> FilterByCategory(int categoryId);
    }
}
