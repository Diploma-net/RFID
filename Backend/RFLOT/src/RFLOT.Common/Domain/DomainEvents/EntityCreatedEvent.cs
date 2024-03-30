using MediatR;

namespace RFLOT.Common.Domain.DomainEvents
{
    public class EntityCreatedEvent<T> : INotification
        where T : IDomainEventEntity
    {
        public T Entity { get; }

        public EntityCreatedEvent(T entity)
        {
            Entity = entity;
        }
    }
}
