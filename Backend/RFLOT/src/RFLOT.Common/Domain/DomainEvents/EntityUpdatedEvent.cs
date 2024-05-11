using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public class EntityUpdatedEvent<T> : INotification
    where T : IDomainEventEntity
{
    public EntityUpdatedEvent(T entity)
    {
        Entity = entity;
    }

    public T Entity { get; }
}