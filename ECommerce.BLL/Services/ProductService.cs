using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.DLL.Extensibility.Entities;
using ECommerce.DLL.Extensibility.Repository;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable CompareOfFloatsByEqualityOperator
namespace ECommerce.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryBase<Product> _productDb;
        private readonly IMapper _mapper;

        public ProductService(
            IRepositoryBase<Product> productDb,
            IMapper mapper)
        {
            this._productDb = productDb;
            this._mapper = mapper;
        }

        public ProductDto GetProduct(int id)
        {
            return this._mapper.Map<ProductDto>(this._productDb.GetById(id));
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return this._mapper.Map<IEnumerable<ProductDto>>(this._productDb.GetAll());
        }

        public IEnumerable<ProductDto> GetProductsWithPagination(int page, int pageSize)
        {
            var products = this._productDb.GetAll()
                     .OrderBy(product => product.Id)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize);

            return this._mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public IEnumerable<ProductDto> SearchProduct(string request) //
        {
            var allProducts = this.GetAllProducts();

            return allProducts.Where(product => product.Name.ToLower().Contains(request.ToLower()));
        }

        public IEnumerable<ProductDto> FilterProductByCategory(int categoryId)
        {
            var allProducts = this._productDb.GetAll().Where(product => product.Id == categoryId);
            var products = this._mapper.Map<IEnumerable<ProductDto>>(allProducts);

            return products;
        }
    }
}
