using System.Collections;
using MediatR;

namespace RFLOT.Common.Domain.DomainEvents;

public class DomainEventCollection : ICollection<INotification>
{
    private readonly LinkedList<INotification> _events = new();

    public int Count => _events.Count;

    public bool IsReadOnly => false;

    public void Add(INotification item)
    {
        if (item is IEventAddStrategy strategy)
            strategy.AddTo(_events);
        else
            _events.AddLast(item);
    }

    public void Clear()
    {
        _events.Clear();
    }

    public bool Contains(INotification item)
    {
        return _events.Contains(item);
    }

    public void CopyTo(INotification[] array, int arrayIndex)
    {
        if (array.Length - (arrayIndex + Count) < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

        foreach (var (e, i) in _events.Select((e, i) => (e, i))) array[arrayIndex + i] = e;
    }

    public IEnumerator<INotification> GetEnumerator()
    {
        return _events.GetEnumerator();
    }

    public bool Remove(INotification item)
    {
        return _events.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IReadOnlyCollection<INotification> AsReadOnly()
    {
        return _events.ToList().AsReadOnly();
    }
}