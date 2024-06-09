using MediatR;
using RFLOT.Application.Equip.Models;
using RFLOT.Domain.Equip.ValueObjects;
using RFLOT.Gateway.Monitoring.Models;

namespace RFLOT.Application.Monitoring.Command;

public class StartMonitoringCommand : IRequest<Dictionary<string, Status>>
{
    public StartMonitoringCommand(string planeName)
    {
        PlaneName = planeName;
    }

    public string PlaneName { get;  }
}