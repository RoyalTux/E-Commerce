using System.Web.Http;
using AutoMapper;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using WebAPI.Models;

namespace ECommerce.WebAPI.Controllers
{
    [RoutePrefix("api/manager/orders")]
    [Authorize(Roles = "manager")]
    public class ManagerController : ApiController
    {
        private readonly IManageService _manage;
        private readonly IMapper _mapper;

        public ManagerController(IManageService manage, IMapper mapper)
        {
            this._manage = manage;
            this._mapper = mapper;
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder([FromBody]OrderView order)
        {
            if (this.ModelState.IsValid)
            {
                var orders = this._mapper.Map<OrderDto>(order);
                var result = this._manage.UpdateOrder(orders);

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

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetOrder(int id)
        {
            var order = this._manage.GetOrder(id);
            if (order == null)
            {
                return this.NotFound();
            }

            var orders = this._mapper.Map<OrderView>(order);
            return this.Ok(orders);
        }
    }
}
