using MediatR;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Domain.Equip.Events;

public class EquipChecked : INotification
{
    public EquipChecked(Guid idEquip, Status status, Guid idReport, Guid idZone, Guid idUser)
    {
        IdEquip = idEquip;
        Status = status;
        IdReport = idReport;
        IdZone = idZone;
        IdUser = idUser;
    }

    public Guid IdEquip { get; }
    public Status Status { get; }
    public Guid IdReport { get; }
    public Guid IdZone { get; }
    public Guid IdUser { get; }
}