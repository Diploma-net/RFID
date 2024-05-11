using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public interface IEventAddStrategy
{
    void AddTo(LinkedList<INotification> events);
}