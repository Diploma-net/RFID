using System.Text.Json;

namespace RFLOT.Infrastructure.Kafka;

public class Message<T>
{
    public Message(string id, T data)
    {
        Id = id;
        Data = data;
    }

    public string Id { get; private set; }
    public T Data { get; private set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}