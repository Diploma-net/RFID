using RFLOT.Common.Domain;
using RFLOT.Domain.Equip.Events;
using RFLOT.Domain.Equip.ValueObjects;
using Type = RFLOT.Domain.Equip.ValueObjects.Type;

namespace RFLOT.Domain.Equip;

public class Equip : Entity<string>
{
    private Equip()
    {
    }

    public Equip(Guid? zoneId, string space, string name, Type type, DateTimeOffset dateTimeStart,
        DateTimeOffset dateTimeEnd, Status lastStatus)
    {
        ZoneId = zoneId;
        Space = space;
        Name = name;
        Type = type;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        LastStatus = lastStatus;
    }

    public Guid? ZoneId { get; private set; }
    public string? Space { get; private set; }
    public string Name { get; private set; }
    public Type Type { get; private set; }
    public DateTimeOffset DateTimeStart { get; private set; }
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

    public void CheckEquip(Status newStatus, Guid idReport,Guid idZone, Guid idUser)
    {
        LastStatus = newStatus;
        AddDomainEvent(new EquipChecked(Id, LastStatus, idReport, idZone, idUser));
    }
}