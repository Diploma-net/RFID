﻿using System.Text.Json;
using Confluent.Kafka;

namespace RFLOT.AuditEvents;

public class CustomValueDeserializer<T> : IDeserializer<T>
{
    public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        return JsonSerializer.Deserialize<T>(data);
    }
}