using System.Web.Http;
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

            Ioc.Unity.Bootstrapper.RegisterTypesTo(container);

            return container;
        }
    }
}