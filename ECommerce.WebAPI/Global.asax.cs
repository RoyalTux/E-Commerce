using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Infrastructure;
using ECommerce.DLL.Infrastructure;
using ECommerce.WebAPI.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.Filter;

// ReSharper disable once StringLiteralTypo
namespace ECommerce.WebAPI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var kernel = new StandardKernel(GetModules());
            kernel.Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));

            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            Bootstraper.Start(kernel);
            ModelBinders.Binders.Add(typeof(ProductDto), new ProductModelBinding());
        }

        private static INinjectModule[] GetModules()
        {
            var bllNinjectModule = new BLLNinjectModule();
            var autoMapperNinjectModule = new AutoMapperNinjectModule();

            return new INinjectModule[] { bllNinjectModule, autoMapperNinjectModule, new DLLNinjectModule(),  };
        }
    }
}
