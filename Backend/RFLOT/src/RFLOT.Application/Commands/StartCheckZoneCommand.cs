using MediatR;
using RFLOT.Application.Models;

namespace RFLOT.Application.Commands;

public class StartCheckZoneCommand : IRequest<OneZoneInfo>
{
    public StartCheckZoneCommand(string idPlane, string nameZone)
    {
        IdPlane = idPlane;
        NameZone = nameZone;
    }

    public string IdPlane { get; }
    public string NameZone { get; }
}