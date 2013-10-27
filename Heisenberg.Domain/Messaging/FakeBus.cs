using System;
using System.Collections.Generic;
using Heisenberg.Domain.Messaging.InfrastructureCrap;

namespace Heisenberg.Domain.Messaging
{
    public class FakeBus : IEventPublisher
    {
        private readonly IDictionary<Type, List<Action<IMessage>>> _routes =
            new Dictionary<Type, List<Action<IMessage>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<IMessage, T>(x => handler(x)));
        }

        public void Publish<T>(T @event) where T : Event
        {
            List<Action<IMessage>> handlers;
            if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;
            foreach (var handler in handlers)
            {
                handler(@event);
            }
        }
    }
}
