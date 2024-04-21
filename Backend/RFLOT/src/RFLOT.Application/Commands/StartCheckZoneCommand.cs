using MediatR;
using RFLOT.Application.Models;

namespace RFLOT.Application.Commands;

public class StartCheckZoneCommand : IRequest<OneZoneInfo>
{
    public StartCheckZoneCommand(string idPlane, string nameZone, string idReport)
    {
        IdPlane = idPlane;
        NameZone = nameZone;
        IdReport = idReport;
    }

    public string IdPlane { get; }
    public string NameZone { get; }
    public string IdReport { get; }
}