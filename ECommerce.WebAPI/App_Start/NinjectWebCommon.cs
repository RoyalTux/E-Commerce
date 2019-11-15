using System;
using System.Web;
using ECommerce.BLL.Extensibility.Infrastructure;
using ECommerce.WebAPI;
using ECommerce.WebAPI.Infrastructure;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.WebApi.DependencyResolver;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

// ReSharper disable InconsistentNaming
namespace ECommerce.WebAPI
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper _bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            _bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            _bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var webApiNinjectModule = new WebApiNinjectModule();
            var bbLNinjectModule = new BLLNinjectModule();
            var autoMapperNinjectModule = new AutoMapperNinjectModule();

            INinjectModule[] modules = { webApiNinjectModule, bbLNinjectModule, autoMapperNinjectModule };

            var kernel = new StandardKernel(modules);

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}
