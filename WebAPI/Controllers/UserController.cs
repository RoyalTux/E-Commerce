using System.Web.Http;
using AutoMapper;
using BLL.Extensibility;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/CartPanel")]
    public class UserController : ApiController
    {
        private readonly IUserService _user;
        private readonly IMapper _mapper;
        private readonly IShoppingCart _iCart;
        private readonly IProductService _outputService;

        public UserController(IProductService outputService, IUserService user, IMapper mapper, IShoppingCart iCart)
        {
            this._outputService = outputService;
            this._user = user;
            this._mapper = mapper;
            this._iCart = iCart;
        }

        [HttpGet]
        [Route("addItem/{id}")]
        public IHttpActionResult AddItem(int id)
        {
            var item = this._outputService.GetProduct(id);
            if (item == null)
            {
                return this.BadRequest();
            }

            var result = this._user.AddItem(item, 1, this._iCart);
            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpGet]
        [Route("removeItem/{id}")]
        public IHttpActionResult RemoveItem(int id)
        {
            var item = this._outputService.GetProduct(id);
            if (item == null)
            {
                return this.BadRequest();
            }

            var result = this._user.RemoveItem(item, this._iCart);
            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpGet]
        [Route("composeOrder")]
        public IHttpActionResult ComposeCart()
        {
            var cart = this._user.ComposeCart(this._iCart);
            if (cart == null)
            {
                return this.NotFound();
            }

            return this.Ok(cart);
        }

        [HttpGet]
        [Route("~/api/OrderPanel/addOrder")]
        public IHttpActionResult MakeOrder()
        {
            var order = this._user.MakeOrder(this._iCart);
            if (order == null)
            {
                return this.NotFound();
            }

            var orderView = this._mapper.Map<OrderView>(order);
            return this.Ok(orderView);
        }
    }
}
