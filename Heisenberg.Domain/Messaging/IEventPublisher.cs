namespace Heisenberg.Domain.Messaging
{
    public interface IEventPublisher
    {
        void Publish<T>(T message) where T : Event;
    }
}
