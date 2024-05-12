using MediatR;
using RFLOT.Common.Domain.Entity;

namespace RFLOT.Common.Domain.DomainEvents;

public abstract class DomainEventEntity : IDomainEntity
{
    private DomainEventCollection? _domainEvents;
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents ??= new DomainEventCollection();
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}