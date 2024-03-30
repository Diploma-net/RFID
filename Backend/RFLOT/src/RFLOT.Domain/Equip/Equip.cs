using RFLOT.Common.Domain.Entity;

namespace RFLOT.Domain.Equip;

public class Equip : IEntity
{
    private Equip() {}
    public Equip(string id, string? idPlane, string space, string name, Type type, DateTimeOffset dateTimeStart, DateTimeOffset dateTimeEnd, Status lastStatus)
    {
        Id = id;
        IdPlane = idPlane;
        Space = space;
        Name = name;
        Type = type;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        LastStatus = lastStatus;
    }

    public string Id { get; private set; }
    public string? IdPlane { get; private set; }
    public string? Space { get; private set; }
    public string Name { get;private set; }
    public Type Type { get;private set; }
    public DateTimeOffset DateTimeStart { get;private set; }
    public DateTimeOffset? DateTimeEnd { get; private set; }
    public Status LastStatus { get; set; }

    public string GetStatusString()
    {
        return LastStatus switch
        {
            Status.Ok => "Ok",
            Status.None => "None",
            Status.NotFound => "NotFound",
            Status.DateFail => "DateFail",
            Status.DateMonth => "DateMonth",
            Status.Arсhive => "Arсhive",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public string GetTypeString()
    {
        return Type switch
        {
            Type.FireExtinguisher => "Огнетушитель",
            Type.InformationCard => "Информационная карточка",
            Type.OxygenMask => "Кислородная маска",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

