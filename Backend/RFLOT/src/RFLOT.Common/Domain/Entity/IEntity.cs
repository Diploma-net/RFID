namespace RFLOT.Common.Domain.Entity;

public interface IEntity<T>
{
    public T Id { get; }
}