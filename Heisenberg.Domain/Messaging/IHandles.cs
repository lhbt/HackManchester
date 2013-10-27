namespace Heisenberg.Domain.Messaging
{
    public interface IHandles<T>
    {
        void Handle(T message);
    }
}
