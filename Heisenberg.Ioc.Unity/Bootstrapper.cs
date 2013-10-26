using Heisenberg.Domain.Interfaces;
using Heisenberg.Twitter;
using Microsoft.Practices.Unity;

namespace Heisenberg.Ioc.Unity
{
    public static class Bootstrapper
    {
        public static void RegisterTypesTo(IUnityContainer container)
        {
            container.RegisterType<ISocialMediaWrapper, TwitterApiWrapper>();
        }
    }
}
