using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;

// ReSharper disable once StringLiteralTypo
namespace WebAPI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IKernel kernel = this.CreateKernel();

            // DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            Bootstraper.Start(kernel);
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load("Ecommerce.Core.dll");

            return kernel;
        }
    }
}
