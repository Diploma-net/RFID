using MediatR;
using Type = RFLOT.Domain.Equip.Type;

namespace RFLOT.Application.Commands;

public class AddNewEquipCommand : IRequest
{
    public AddNewEquipCommand(string id, Guid zoneId, string planePlace, string name, Type type, DateTimeOffset dateTimeEnd)
    {
        Id = id;
        ZoneId = zoneId;
        PlanePlace = planePlace;
        Name = name;
        Type = type;
        DateTimeEnd = dateTimeEnd;
    }

    public string Id { get; private set; }
    public Guid ZoneId { get; private set; }
    public string PlanePlace { get; private set; }
    public string Name { get;private set; }
    public Type Type { get;private set; }
    public DateTimeOffset DateTimeEnd { get; private set; }

}