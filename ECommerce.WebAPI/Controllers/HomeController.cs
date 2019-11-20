using System.Web.Http;

// ReSharper disable PossibleMultipleEnumeration
namespace ECommerce.WebAPI.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {


        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok("Hello");
        }

    }
}
