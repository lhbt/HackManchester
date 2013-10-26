using System.Web.Http;
using Heisenberg.Domain.Interfaces;
using Heisenberg.Twitter;
using Microsoft.Practices.Unity;

namespace Heisenberg
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ISocialMediaWrapper, TwitterApiWrapper>();

            return container;
        }
    }
}