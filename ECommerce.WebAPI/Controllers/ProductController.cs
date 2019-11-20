using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Infrastructure;
using ECommerce.WebAPI.Models;

// ReSharper disable PossibleMultipleEnumeration
namespace ECommerce.WebAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = this._productService.GetProduct(id);
            if (product == null)
            {
                return this.NotFound();
            }

            var products = this._mapper.Map<ProductView>(product);

            return this.Ok(products);
        }

        [HttpGet]
        [Route("pagination")]
        public IHttpActionResult PagingProductsList([FromUri]PaginationParams parameters)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var page = parameters.CurrentPage;
            var pageSize = parameters.PageSize;

            var products = this._productService.GetProductsWithPagination(page, pageSize);

            if (!products.Any())
            {
                return this.NotFound();
            }

            var model = new ProductsListViewModel()
            {
                Products = this._mapper.Map<IEnumerable<ProductView>>(products),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ProductsPerPage = pageSize,
                    TotalProducts = this._productService.GetAllProducts().Count(),
                },
            };

            return this.Ok(model);
        }

        [HttpGet]
        [Route("allProducts")]
        public IHttpActionResult GetAllProducts()
        {
            var products = this._productService.GetAllProducts();

            if (!products.Any())
            {
                return this.NotFound();
            }

            var product = this._mapper.Map<IEnumerable<ProductView>>(products);

            return this.Ok(product);
        }

        [HttpGet]
        [Route("search")]
        public IHttpActionResult Search([FromUri]string request)
        {
            var searchProducts = this._productService.Search(request);

            if (!searchProducts.Any())
            {
                return this.NotFound();
            }

            var searchProduct = this._mapper.Map<IEnumerable<ProductView>>(searchProducts);

            return this.Ok(searchProduct);
        }

        [HttpGet]
        [Route("sortBy/{sortCriteria}")]
        public IHttpActionResult SortBy(SortCriteriaView sortCriteria = SortCriteriaView.Name)
        {
            var criteria = this._mapper.Map<BLLSortCriteria>(sortCriteria);
            var sortedProducts = this._mapper.Map<IEnumerable<ProductView>>(this._productService.SortBy(criteria));

            if (!sortedProducts.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(sortedProducts);
        }

        [HttpGet]
        [Route("sortByDescending/{sortCriteria}")]
        public IHttpActionResult SortByDescending(SortCriteriaView sortCriteria = SortCriteriaView.Name)
        {
            var criteria = this._mapper.Map<BLLSortCriteria>(sortCriteria);
            var sortedProducts = this._mapper.Map<IEnumerable<ProductView>>(this._productService.SortByDescending(criteria));

            if (!sortedProducts.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(sortedProducts);
        }

        [HttpGet]
        [Route("filterByCategory/{id}")]
        public IHttpActionResult FilterByCategory(int id)
        {
            var products = this._productService.FilterByCategory(id);
            var filterProducts = this._mapper.Map<IEnumerable<ProductView>>(products);

            if (!filterProducts.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(filterProducts);
        }
    }
}
