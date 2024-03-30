using MediatR;

namespace RFLOT.Common.Domain.DomainEvents
{
    public class EntityUpdatedEvent<T> : INotification
        where T : IDomainEventEntity
    {
        public T Entity { get; }

        public EntityUpdatedEvent(T entity)
        {
            Entity = entity;
        }
    }
}
