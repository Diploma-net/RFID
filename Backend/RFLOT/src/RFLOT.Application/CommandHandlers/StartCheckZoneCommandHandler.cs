using MediatR;
using Microsoft.EntityFrameworkCore;
using RFLOT.Application.Commands;
using RFLOT.Application.Models;
using RFLOT.Infrastructure.Equip;

namespace RFLOT.Application.CommandHandlers;

public class StartCheckZoneCommandHandler : IRequestHandler<StartCheckZoneCommand, OneZoneInfo>
{
    private readonly RfidDbContext _dbContext;

    public StartCheckZoneCommandHandler(RfidDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OneZoneInfo> Handle(StartCheckZoneCommand command, CancellationToken cancellationToken)
    {
        var plane = await _dbContext.Planes.FirstOrDefaultAsync(p => p.Id == command.IdPlane, cancellationToken: cancellationToken);
        return new OneZoneInfo
        {
            Name = command.NameZone,
            Spaces = plane.Zones.FirstOrDefault(z => z.Name == command.NameZone).Spaces
        };
    }
}