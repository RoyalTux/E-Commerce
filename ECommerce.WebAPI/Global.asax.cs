using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ECommerce.BLL.Extensibility.Dto;
using ECommerce.BLL.Extensibility.Infrastructure;
using ECommerce.DLL.Infrastructure;
using ECommerce.WebAPI.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.FilterBindingSyntax;
using FilterScope = System.Web.Http.Filters.FilterScope;

//using Ninject;

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

            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var kernel = new StandardKernel(GetModules());
            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            //var webNinject = new NinjectWebDependencyResolver(Bootstraper.Kernel);
            //DependencyResolver.SetResolver(webNinject);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            kernel.BindHttpFilter<ModelValidatorAttribute>((FilterScope) System.Web.Mvc.FilterScope.Global);
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
    //private IKernel CreateKernel()
    //{
    //    var kernel = new StandardKernel();

    //    return kernel;
    //}
}
