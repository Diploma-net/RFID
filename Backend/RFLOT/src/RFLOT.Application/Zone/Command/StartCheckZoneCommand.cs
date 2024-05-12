using MediatR;
using RFLOT.Application.Zone.Models;

namespace RFLOT.Application.Zone.Command;

public class StartCheckZoneCommand : IRequest<OneZoneInfo>
{
    public StartCheckZoneCommand(Guid idZone, Guid idReport, Guid idUser)
    {
        IdZone = idZone;
        IdReport = idReport;
        IdUser = idUser;
    }

    public Guid IdZone { get; }
    public Guid IdUser { get; }
    public Guid IdReport { get; }
}