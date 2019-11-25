using System.Web;
using System.Web.Http;
using ECommerce.BLL.Extensibility;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.WebAPI.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ECommerce.WebAPI.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private AccountController()
        {
        }

        private IAccountService AccountService => HttpContext.Current.GetOwinContext().GetUserManager<IAccountService>();

        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login(string email, string password)
        {
            var model = new LoginModel() { Email = email, Password = password };
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userDto = new UserProfileDto { Email = model.Email, Password = model.Password };
            var claim = this.AccountService.Authenticate(userDto);
            if (claim == null)
            {
                return this.Ok("Wrong login or password.");
            }
            else
            {
                this.AuthenticationManager.SignOut();
                this.AuthenticationManager.SignIn(
                    new AuthenticationProperties
                {
                    IsPersistent = true,
                }, claim);
            }

            return this.Ok(true);
        }

        [HttpPost]
        [Route("logout")]
        public IHttpActionResult Logout()
        {
            this.AuthenticationManager.SignOut();
            return this.Ok();
        }

        [HttpGet]
        [Route("register")]
        public IHttpActionResult Register(string name, string address, string password, string confirmPassword, string email)
        {
            var model = new RegistrationModel()
            {
                Password = password,
                Email = email,
                Address = address,
                ConfirmPassword = confirmPassword,
                Name = name,
            };

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userDto = new UserProfileDto
            {
                Email = model.Email,
                Password = model.Password,
                Address = model.Address,
                UserName = model.Name,
                Name = model.Name,
                Role = "user",
            };
            var operationDetails = this.AccountService.Create(userDto);

            return this.Ok(operationDetails);
        }
    }
}
