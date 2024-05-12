using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public interface IDomainEntity
{
    IReadOnlyCollection<INotification> DomainEvents { get; }

    void AddDomainEvent(INotification eventItem);
    void ClearDomainEvents();
}