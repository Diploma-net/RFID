using MediatR;

namespace RFLOT.Common.Domain.DomainEvents
{
    public class DomainEventEntity : IDomainEventEntity
    {
        private DomainEventCollection? _domainEvents;
        public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new();
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
