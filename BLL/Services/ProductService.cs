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
            var products = this._db.Products.GetAll()
                     .OrderBy(product => product.Id)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize);

            return this._mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public IEnumerable<ProductDto> Search(string request)
        {
            var allProducts = this.GetAllProducts();

            return allProducts.Where(product => product.Name.ToLower().Contains(request.ToLower()));
        }

        public IEnumerable<ProductDto> SortBy(BLLSortCriteria sortParam)
        {
            var allProducts = this.GetAllProducts();

            IEnumerable<ProductDto> res = sortParam == BLLSortCriteria.Name
                ? allProducts.OrderBy(x => x.Name)
                : allProducts.OrderBy(x => x.Price);

            return res;
        }

        public IEnumerable<ProductDto> SortByDescending(BLLSortCriteria sortParam)
        {
            var allProducts = this.GetAllProducts();

            IEnumerable<ProductDto> res = sortParam == BLLSortCriteria.Name
                ? allProducts.OrderByDescending(x => x.Name)
                : allProducts.OrderByDescending(x => x.Price);

            return res;
        }

        public IEnumerable<ProductDto> FilterByCategory(int subCategoryId)
        {
            var allProducts = this._db.Products.GetAll().Where(product => product.SubCategoryId == subCategoryId);
            var products = this._mapper.Map<IEnumerable<ProductDto>>(allProducts);

            return products;
        }

        private static IEnumerable<ProductDto> FilterByPrice(IEnumerable<ProductDto> products, int minPrice, int maxPrice)
        {
            return products.Where(product => product.Price >= minPrice && product.Price <= maxPrice);
        }

        private static int GetDefaultMinPrice(IEnumerable<ProductDto> products)
        {
            return (int)products.Min(x => x.Price);
        }

        private static int GetDefaultMaxPrice(IEnumerable<ProductDto> products)
        {
            return (int)products.Max(x => x.Price);
        }
    }
}
