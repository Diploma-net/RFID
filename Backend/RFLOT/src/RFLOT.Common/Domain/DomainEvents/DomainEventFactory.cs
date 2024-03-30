using MediatR;

namespace RFLOT.Common.Domain.DomainEvents
{
    public static class DomainEventFactory
    {
        private static readonly System.Type _entityCreatedEventGenericRef = typeof(EntityCreatedEvent<>);
        public static INotification CreateEntityCreatedEvent(object entity)
        {
            var type = entity.GetType();

            var typedRef = _entityCreatedEventGenericRef.MakeGenericType(type);
            var instance = typedRef.GetConstructor(new[] { type }).Invoke(new[] { entity });

            return (INotification)instance;
        }

        private static readonly System.Type _entityDeletedEventGenericRef = typeof(EntityDeletedEvent<>);
        public static INotification CreateEntityDeletedEvent(object entity)
        {
            var type = entity.GetType();

            var typedRef = _entityDeletedEventGenericRef.MakeGenericType(type);
            var instance = typedRef.GetConstructor(new[] { type }).Invoke(new[] { entity });

            return (INotification)instance;
        }

        private static readonly System.Type _entityUpdatedEventGenericRef = typeof(EntityUpdatedEvent<>);
        public static INotification CreateEntityUpdatedEvent(object entity)
        {
            var type = entity.GetType();

            var typedRef = _entityUpdatedEventGenericRef.MakeGenericType(type);
            var instance = typedRef.GetConstructor(new[] { type }).Invoke(new[] { entity });

            return (INotification)instance;
        }
    }
}
