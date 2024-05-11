using RFLOT.Common.Domain.Entity;

namespace RFLOT.Common.Domain;

public interface IAggregateRoot<T> : IEntity<T>
{
    public T Id { get; }
}