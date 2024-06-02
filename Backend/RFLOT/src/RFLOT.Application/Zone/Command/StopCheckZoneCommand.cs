using MediatR;

namespace RFLOT.Application.Zone.Command;

public class StopCheckZoneCommand : IRequest
{
    public StopCheckZoneCommand(Guid idZone, Guid idUser, Guid idReport)
    {
        IdZone = idZone;
        IdUser = idUser;
        IdReport = idReport;
    }

    public Guid IdZone { get; }
    public Guid IdUser { get; }
    public Guid IdReport { get; }
}