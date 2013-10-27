using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messaging;
using Heisenberg.GitHub;
using Heisenberg.Twitter;
using Microsoft.Practices.Unity;

namespace Heisenberg.Ioc.Unity
{
    public static class Bootstrapper
    {
        public static void RegisterTypesTo(IUnityContainer container)
        {
            container.RegisterType<ISocialMediaWrapper, TwitterApiWrapper>();
            container.RegisterType<ISourceControlParser, GitHubParser>
                (new InjectionConstructor(@"C:\Users\laurent\Documents\GitHub\HackManchester"));

            var bus = new FakeBus();

            container.RegisterInstance(((IEventPublisher) bus));
        }
    }
}
