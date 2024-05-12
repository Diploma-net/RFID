using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Gateway.Monitoring.Models;

public class Message
{
    public Message(string space, Status status)
    {
        Space = space;
        Status = status;
    }

    public string Space { get; }
    public Status Status { get; }
}