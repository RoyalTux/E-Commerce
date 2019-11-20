using System.Linq;
using ECommerce.Core.Extensibility;
using Ninject;

// ReSharper disable once IdentifierTypo
namespace ECommerce.WebAPI
{
    public static class Bootstraper
    {
        private static IKernel _kernel;
        public static IKernel Kernel
        {
            get => Bootstraper._kernel;
            set => _kernel = value;
        }

        public static void Start(IKernel kernel)
        {
            kernel.GetAll<IInitializer>()
                .ToList()
                .ForEach(initializer => initializer.Init());
        }
    }

}
