using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Commands;
using RFLOT.Application.Models;
using RFLOT.Domain.Equip;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.CommandHandlers;

public class CheckEquipCommandHandler : IRequestHandler<CheckEquipCommand, EquipInfo>
{
    private readonly RfidContext _context;

    public CheckEquipCommandHandler(RfidContext context)
    {
        _context = context;
    }

    public async Task<EquipInfo> Handle(CheckEquipCommand command, CancellationToken cancellationToken)
    {
        var equip =
            await _context.Equips.FirstOrDefaultAsync(e => e.Id == command.RfId,
                cancellationToken: cancellationToken) ?? throw new ApplicationException("АСО не найдено");

        return new EquipInfo
        {
            LastStatus = equip.GetStatusString(),
            Name = equip.Name,
            Space = equip.Space ?? "АСО не привязоно к определенному месту",
            Type = equip.GetTypeString()
        };
    }
}