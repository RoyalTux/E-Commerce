using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using BLL.Extensibility;
using BLL.Extensibility.Infrastructure;
using WebAPI.Models;

// ReSharper disable PossibleMultipleEnumeration
namespace WebAPI.Controllers
{
    [RoutePrefix("api/output")] // переименовать на product
    public class ProductController : ApiController
    {
        private readonly IProductService _outputService; // переименовать
        private readonly IMapper _mapper;

        public ProductController()
        {
        }

        public ProductController(IProductService outputService, IMapper mapper)
        {
            this._outputService = outputService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("items/get/{id}")]
        public IHttpActionResult GetItem(int id)
        {
            var item = this._outputService.GetProduct(id);
            if (item == null)
            {
                return this.NotFound();
            }

            var items = this._mapper.Map<ProductView>(item);

            return this.Ok(items);
        }

        [HttpGet]
        [Route("pagination")]
        public IHttpActionResult PagingItemsList([FromUri]PaginationParams parameters)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var page = parameters.CurrentPage;
            var pageSize = parameters.PageSize;

            var items = this._outputService.GetProductsWithPagination(page, pageSize);

            if (!items.Any())
            {
                return this.NotFound();
            }

            var model = new ItemsListViewModel()
            {
                Items = this._mapper.Map<IEnumerable<ProductView>>(items),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = this._outputService.GetAllProducts().Count(),
                },
            };

            return this.Ok(model);
        }

        [HttpGet]
        [Route("all_items")]
        public IHttpActionResult GetAllItems()
        {
            var items = this._outputService.GetAllProducts();

            if (!items.Any())
            {
                return this.NotFound();
            }

            var item = this._mapper.Map<IEnumerable<ProductView>>(items);

            return this.Ok(item);
        }

        [HttpGet]
        [Route("search")]
        public IHttpActionResult Search([FromUri]string request)
        {
            var searchItems = this._outputService.Search(request);

            if (!searchItems.Any())
            {
                return this.NotFound();
            }

            var searchItem = this._mapper.Map<IEnumerable<ProductView>>(searchItems);

            return this.Ok(searchItem);
        }

        [HttpGet]
        [Route("sort_by/{sortCriteria}")]
        public IHttpActionResult SortBy(SortCriteriaView sortCriteria = SortCriteriaView.Name)
        {
            var criteria = this._mapper.Map<BLLSortCriteria>(sortCriteria);
            var sortedItems = this._mapper.Map<IEnumerable<ProductView>>(this._outputService.SortBy(criteria));

            if (!sortedItems.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(sortedItems);
        }

        [HttpGet]
        [Route("sort_by_descending/{sortCriteria}")]
        public IHttpActionResult SortByDescending(SortCriteriaView sortCriteria = SortCriteriaView.Name)
        {
            var criteria = this._mapper.Map<BLLSortCriteria>(sortCriteria);
            var sortedItems = this._mapper.Map<IEnumerable<ProductView>>(this._outputService.SortByDescending(criteria));

            if (!sortedItems.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(sortedItems);
        }

        [HttpGet]
        [Route("filter_by_category/{id}")]
        public IHttpActionResult FilterByCategory(int id)
        {
            var items = this._outputService.FilterByCategory(id);
            var filterItems = this._mapper.Map<IEnumerable<ProductView>>(items);

            if (!filterItems.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(filterItems);
        }
    }
}
