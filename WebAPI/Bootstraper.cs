using System.Linq;
using ECommerce.Core.Extensibility;
using Ninject;

// ReSharper disable once IdentifierTypo
namespace ECommerce.WebAPI
{
    public static class Bootstraper
    {
        public static void Start(IKernel kernel)
        {
            kernel.GetAll<IInitializer>()
                .ToList()
                .ForEach(initializer => initializer.Init());
        }
    }
}