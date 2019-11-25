using AutoMapper;
using ECommerce.BLL.Infrastructure;
using Ninject.Modules;

namespace ECommerce.WebAPI.Infrastructure
{
    public class AutoMapperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private static IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.GetType());

                config.AddProfile(new WebApiMappingConfig());
                config.AddProfile(new BLLAutomapperProfile());
                config.AddProfiles("ECommerce.DLL");
            });

            Mapper.AssertConfigurationIsValid();

            return Mapper.Instance;
        }
    }
}