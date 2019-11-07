using System.Web;
using System.Web.Http;
using BLL.Extensibility;
using BLL.Extensibility.Dto;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AccountController()
        {
        }

        private static IAccountService AccountService => HttpContext.Current.GetOwinContext().GetUserManager<IAccountService>(); // нельзя замокать и статик нельзя
        // почитать про разницу стрелочной ф-ии и get; set;

        private static IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        [HttpGet]
        [Route("Login")]
        public IHttpActionResult Login(string email, string password)
        {
            var model = new LoginModel() { Email = email, Password = password };
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userDto = new UserDto { Email = model.Email, Password = model.Password };
            var claim = AccountService.Authenticate(userDto);
            if (claim == null)
            {
                return this.Ok("Wrong login or password.");
            }
            else
            {
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(
                    new AuthenticationProperties
                {
                    IsPersistent = true,
                }, claim);
            }

            return this.Ok(true);
        }

        [HttpPost]
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return this.Ok();
        }

        [HttpGet]
        [Route("Register")]
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

            var userDto = new UserDto
            {
                Email = model.Email,
                Password = model.Password,
                Address = model.Address,
                UserName = model.Name,
                Name = model.Name,
                Role = "user",
            };
            var operationDetails = AccountService.Create(userDto);

            return this.Ok(operationDetails);
        }
    }
}
