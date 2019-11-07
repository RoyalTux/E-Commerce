using System.Linq;
using Core.Extensibility;
using Ninject;

// ReSharper disable once IdentifierTypo
namespace WebAPI
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