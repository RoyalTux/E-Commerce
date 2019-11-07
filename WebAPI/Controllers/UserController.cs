using System.Web.Http;
using AutoMapper;
using BLL.Extensibility;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/user/cartPanel")]
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
        [Route("addProduct/{id}")]
        public IHttpActionResult AddProduct(int id)
        {
            var product = this._outputService.GetProduct(id);
            if (product == null)
            {
                return this.BadRequest();
            }

            var result = this._user.AddProduct(product, 1, this._iCart);
            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpGet]
        [Route("removeProduct/{id}")]
        public IHttpActionResult RemoveProduct(int id)
        {
            var product = this._outputService.GetProduct(id);
            if (product == null)
            {
                return this.BadRequest();
            }

            var result = this._user.RemoveProduct(product, this._iCart);
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
        [Route("~/api/user/orderPanel/addOrder")]
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
