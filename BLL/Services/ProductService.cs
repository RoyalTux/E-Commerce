using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Extensibility;
using BLL.Extensibility.Dto;
using BLL.Extensibility.Infrastructure;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable CompareOfFloatsByEqualityOperator
namespace BLL.Services
{
    internal class ProductService : IProductService
    {
        private readonly IShopService _db;
        private readonly IMapper _mapper;

        public ProductService(IShopService db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public ProductDto GetProduct(int id)
        {
            return this._mapper.Map<ProductDto>(this._db.Products.GetById(id));
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return this._mapper.Map<IEnumerable<ProductDto>>(this._db.Products.GetAll());
        }

        public IEnumerable<ProductDto> GetProductsWithPagination(int page, int pageSize)
        {
            var itemsUoW = this._db.Products.GetAll()
                     .OrderBy(item => item.Id)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize);

            return this._mapper.Map<IEnumerable<ProductDto>>(itemsUoW);
        }

        public IEnumerable<ProductDto> Search(string request)
        {
            var allItems = this.GetAllProducts();

            return allItems.Where(item => item.Name.ToLower().Contains(request.ToLower()));
        }

        public IEnumerable<ProductDto> SortBy(BLLSortCriteria sortParam)
        {
            var allItems = this.GetAllProducts();

            IEnumerable<ProductDto> res = sortParam == BLLSortCriteria.Name
                ? allItems.OrderBy(x => x.Name)
                : allItems.OrderBy(x => x.Price);

            return res;
        }

        public IEnumerable<ProductDto> SortByDescending(BLLSortCriteria sortParam)
        {
            var allItems = this.GetAllProducts();

            IEnumerable<ProductDto> res = sortParam == BLLSortCriteria.Name
                ? allItems.OrderByDescending(x => x.Name)
                : allItems.OrderByDescending(x => x.Price);

            return res;
        }

        public IEnumerable<ProductDto> FilterByCategory(int categoryId)
        {
            var allItems = this._db.Products.GetAll().Where(item => item.CategoryId == categoryId);
            var items = this._mapper.Map<IEnumerable<ProductDto>>(allItems);

            return items;
        }

        private static IEnumerable<ProductDto> FilterByPrice(IEnumerable<ProductDto> items, int minPrice, int maxPrice)
        {
            return items.Where(item => item.Price >= minPrice && item.Price <= maxPrice);
        }

        private static int GetDefaultMinPrice(IEnumerable<ProductDto> items)
        {
            return (int)items.Min(x => x.Price);
        }

        private static int GetDefaultMaxPrice(IEnumerable<ProductDto> items)
        {
            return (int)items.Max(x => x.Price);
        }
    }
}
