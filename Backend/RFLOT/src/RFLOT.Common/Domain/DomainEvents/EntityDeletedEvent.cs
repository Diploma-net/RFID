using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public class EntityDeletedEvent<T> : INotification
    where T : IDomainEntity
{
    public EntityDeletedEvent(T entity)
    {
        Entity = entity;
    }

    public T Entity { get; }
}