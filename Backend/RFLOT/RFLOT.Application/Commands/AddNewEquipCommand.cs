using MediatR;

namespace RFLOT.Application.Commands;

public class AddNewEquipCommand : IRequest
{
    public AddNewEquipCommand(string id, Guid zoneId, string planePlace, string name, int type, DateTimeOffset dateTimeEnd)
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
    public int Type { get;private set; }
    public DateTimeOffset DateTimeEnd { get; private set; }

}