using System;

using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Api.DomainEvents;

public class RecursiveDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Queue<IDomainEvent> _queue = new();

    public RecursiveDomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Enqueue(IDomainEvent domainEvent)
    {
        _queue.Enqueue(domainEvent);
    }

    public async Task DispatchAllAsync(CancellationToken cancellationToken = default)
    {
        while (_queue.Count > 0)
        {
            var domainEvent = _queue.Dequeue();

            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = _serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                await (Task)handlerType
                    .GetMethod("HandleAsync")!
                    .Invoke(handler, new object[] { domainEvent, cancellationToken })!;
            }
        }
    }
}
