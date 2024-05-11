using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public class EntityCreatedEvent<T> : INotification
    where T : IDomainEventEntity
{
    public EntityCreatedEvent(T entity)
    {
        Entity = entity;
    }

    public T Entity { get; }
}