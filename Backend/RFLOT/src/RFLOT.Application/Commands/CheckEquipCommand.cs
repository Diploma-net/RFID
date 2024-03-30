using MediatR;
using RFLOT.Application.Models;

namespace RFLOT.Application.Commands;

public class CheckEquipCommand : IRequest<EquipInfo>
{
    public CheckEquipCommand(string rfId)
    {
        RfId = rfId;
    }

    public string RfId { get; }
}