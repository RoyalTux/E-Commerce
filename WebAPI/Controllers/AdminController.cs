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
        [Route("items/add")]
        public IHttpActionResult AddItem([FromBody]ProductView itemView)
        {
            if (this.ModelState.IsValid)
            {
                var item = this._mapper.Map<ProductDto>(itemView);
                var result = this._adminService.AddProduct(item);

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
        [Route("items/edit")]
        [Authorize(Roles = "manager")]
        public IHttpActionResult UpdateItem([FromBody]ProductView item)
        {
            if (this.ModelState.IsValid)
            {
                var items = this._mapper.Map<ProductDto>(item);
                var result = this._adminService.UpdateProduct(items);

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
        [Route("items/delete/{id}")]
        public IHttpActionResult DeleteItem(int id)
        {
            var result = this._adminService.RemoveProduct(id);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpGet]
        [Route("items/get/{id}")]
        public IHttpActionResult GetItem(int id)
        {
            var item = this._adminService.GetProduct(id);

            if (item == null)
            {
                return this.NotFound();
            }

            var items = this._mapper.Map<ProductView>(item);
            return this.Ok(items);
        }
    }
}
