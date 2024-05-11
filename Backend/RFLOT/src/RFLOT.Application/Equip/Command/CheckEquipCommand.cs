using MediatR;
using RFLOT.Application.Equip.Models;

namespace RFLOT.Application.Equip.Command;

public class CheckEquipCommand : IRequest<EquipInfo>
{
    public CheckEquipCommand(Guid rfId)
    {
        RfId = rfId;
    }

    public Guid RfId { get; }
}