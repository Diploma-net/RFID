using Confluent.Kafka;

namespace RFLOT.Infrastructure.Kafka;

public static class Producer<T>
{
    private const string Host = "localhost";
    private const int Port = 9092;
    private const string Topic = "add-event";

    static ProducerConfig GetProducerConfig()
    {
        return new ProducerConfig
        {
            BootstrapServers = $"{Host}:{Port}"
        };
    }

    public static async Task ProduceAsync(T data)
    {
        using var producer = new ProducerBuilder<Null, T>(GetProducerConfig())
            .SetValueSerializer(new CustomValueSerializer<T>())
            .Build();
        await producer.ProduceAsync(Topic, new Message<Null, T> { Value = data });
    }
}