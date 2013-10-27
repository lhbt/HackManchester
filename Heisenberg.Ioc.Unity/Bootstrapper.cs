using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;
using Heisenberg.FakeDataStore;
using Heisenberg.GitHub;
using Heisenberg.MongoDataStore;
using Heisenberg.Twitter;
using Microsoft.Practices.Unity;

namespace Heisenberg.Ioc.Unity
{
    public static class Bootstrapper
    {
        public static void RegisterTypesTo(IUnityContainer container)
        {
            container.RegisterType<ISocialMediaWrapper, TwitterApiWrapper>();
            container.RegisterType<ISourceControlParser, GitHubApiParser>
                (new InjectionConstructor("lhbt", "hackmanchester"));

            container.RegisterType<IBuildStatusReadModel, FakeBuildStatusReadModel>();
            container.RegisterType<ITracer, Tracer>();

            var bus = new FakeBus();
            var fakeReadModel = new FakeBuildStatusReadModel();
            bus.RegisterHandler<BuildSucceeded>(fakeReadModel.Handle);
            bus.RegisterHandler<BuildFailed>(fakeReadModel.Handle);
            
            container.RegisterInstance(((IEventPublisher) bus));
        }
    }
}
