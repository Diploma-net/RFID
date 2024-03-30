using MediatR;

namespace RFLOT.Common.Domain.DomainEvents
{
    public class EntityDeletedEvent<T> : INotification
        where T : IDomainEventEntity
    {
        public T Entity { get; }

        public EntityDeletedEvent(T entity)
        {
            Entity = entity;
        }
    }
}
