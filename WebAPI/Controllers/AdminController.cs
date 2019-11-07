using System.Web.Http;
using AutoMapper;
using BLL.Extensibility;
using BLL.Extensibility.Dto;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/adminPanel")]
    [Authorize(Roles = "admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            this._adminService = adminService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("categories/add")]
        public IHttpActionResult AddCategory([FromBody]CategoryView category)
        {
            if (this.ModelState.IsValid)
            {
                var categories = this._mapper.Map<CategoryDto>(category);
                var result = this._adminService.AddCategory(categories);

                if (result)
                {
                    return this.Ok();
                }
            }
            else
            {
                return this.BadRequest(this.ModelState);
            }

            return this.BadRequest();
        }

        [HttpPut]
        [Route("categories/edit")]
        public IHttpActionResult UpdateCategory([FromBody]CategoryView category)
        {
            if (this.ModelState.IsValid)
            {
                var categories = this._mapper.Map<CategoryDto>(category);
                var result = this._adminService.UpdateCategory(categories);

                if (result)
                {
                    return this.Ok();
                }
            }
            else
            {
                return this.BadRequest(this.ModelState);
            }

            return this.BadRequest();
        }

        [HttpDelete]
        [Route("categories/delete/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var result = this._adminService.RemoveCategory(id);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpGet]
        [Route("categories/get/{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            var category = this._adminService.GetCategory(id);

            if (category == null)
            {
                return this.NotFound();
            }

            var categories = this._mapper.Map<CategoryView>(category);
            return this.Ok(categories);
        }

        [HttpPost]
        [Route("products/add")]
        public IHttpActionResult AddProduct([FromBody]ProductView productView)
        {
            if (this.ModelState.IsValid)
            {
                var product = this._mapper.Map<ProductDto>(productView);
                var result = this._adminService.AddProduct(product);

                if (result)
                {
                    return this.Ok();
                }
            }
            else
            {
                return this.BadRequest(this.ModelState);
            }

            return this.BadRequest();
        }

        [HttpPut]
        [Route("products/edit")]
        [Authorize(Roles = "manager")]
        public IHttpActionResult UpdateProduct([FromBody]ProductView productView)
        {
            if (this.ModelState.IsValid)
            {
                var product = this._mapper.Map<ProductDto>(productView);
                var result = this._adminService.UpdateProduct(product);

                if (result)
                {
                    return this.Ok();
                }
            }
            else
            {
                return this.BadRequest(this.ModelState);
            }

            return this.BadRequest();
        }

        [HttpDelete]
        [Route("products/delete/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            var result = this._adminService.RemoveProduct(id);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpGet]
        [Route("products/get/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = this._adminService.GetProduct(id);

            if (product == null)
            {
                return this.NotFound();
            }

            var products = this._mapper.Map<ProductView>(product);
            return this.Ok(products);
        }
    }
}
