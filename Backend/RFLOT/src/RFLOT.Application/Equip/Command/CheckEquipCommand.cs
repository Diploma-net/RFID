using MediatR;
using RFLOT.Application.Equip.Models;
using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Application.Equip.Command;

public class CheckEquipCommand : IRequest<EquipInfo>
{
    public CheckEquipCommand(Guid idEquip, Status statusEquip, Guid idZone, Guid idReport, Guid idUser)
    {
        IdEquip = idEquip;
        StatusEquip = statusEquip;
        IdZone = idZone;
        IdReport = idReport;
        IdUser = idUser;
    }

    public Guid IdEquip { get; }
    public Status StatusEquip { get; }
    public Guid IdZone { get; }
    public Guid IdReport { get; }
    public Guid IdUser { get; }
}