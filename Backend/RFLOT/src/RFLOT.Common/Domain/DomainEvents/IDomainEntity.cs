using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public interface IDomainEventEntity
{
    IReadOnlyCollection<INotification> DomainEvents { get; }

    void AddDomainEvent(INotification eventItem);
    void ClearDomainEvents();
}