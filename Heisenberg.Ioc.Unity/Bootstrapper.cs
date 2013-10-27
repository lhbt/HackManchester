using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;
using Heisenberg.FakeDataStore;
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
<<<<<<< HEAD
            container.RegisterType<ISourceControlParser, GitHubApiParser>
                (new InjectionConstructor("lhbt", "hackmanchester"));
=======
            container.RegisterType<ISourceControlParser, GitHubParser>
                (new InjectionConstructor(@"C:\Users\laurent\Documents\GitHub\HackManchester"));
            container.RegisterType<IBuildStatusReadModel, FakeBuildStatusReadModel>();

            var bus = new FakeBus();
            var fakeReadModel = new FakeBuildStatusReadModel();
            bus.RegisterHandler<BuildSucceeded>(fakeReadModel.Handle);
            bus.RegisterHandler<BuildFailed>(fakeReadModel.Handle);
            
            container.RegisterInstance(((IEventPublisher) bus));
>>>>>>> 1a39b3eff1f7ff1c2354af4ac24f23a6a4e37c07
        }
    }
}
