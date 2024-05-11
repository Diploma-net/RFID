using MediatR;
using RFLOT.Application.Zone.Models;

namespace RFLOT.Application.Zone.Command;

public class StartCheckZoneCommand : IRequest<OneZoneInfo>
{
    public StartCheckZoneCommand(string idPlane, string nameZone, Guid idReport)
    {
        IdPlane = idPlane;
        NameZone = nameZone;
        IdReport = idReport;
    }

    public string IdPlane { get; }
    public string NameZone { get; }
    public Guid IdReport { get; }
}