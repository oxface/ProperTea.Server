using Microsoft.Extensions.DependencyInjection;

using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Infrastructure.Core;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    private readonly PriorityQueue<IDomainEvent, int> _events;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _events = new PriorityQueue<IDomainEvent, int>();
    }

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
            var handlers = _serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                await (Task)handlerType
                    .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))!
                    .Invoke(handler, [domainEvent, cancellationToken])!;
            }
        }
    }
}
