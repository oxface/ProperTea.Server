using Microsoft.Extensions.DependencyInjection;
using ProperTea.Shared.Domain.DomainEvents;

namespace ProperTea.Shared.Infrastructure.Events;

public class DomainEventDispatcher(IServiceProvider serviceProvider) : IDomainEventDispatcher
{
    private readonly PriorityQueue<IDomainEvent, int> _events = new();

    public void Enqueue(IDomainEvent domainEvent)
    {
        var priority = (domainEvent as IPrioritizedDomainEvent)?.Priority ?? 0;
        _events.Enqueue(domainEvent, priority);
    }

    public async Task DispatchAllAsync(CancellationToken cancellationToken = default)
    {
        while (_events.TryDequeue(out var domainEvent, out _))
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var handlers = serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                await (Task)handlerType
                    .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))!
                    .Invoke(handler, [domainEvent, cancellationToken])!;
            }
        }
    }
}
