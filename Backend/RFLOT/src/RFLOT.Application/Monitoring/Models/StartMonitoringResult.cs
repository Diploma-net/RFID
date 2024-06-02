using RFLOT.Domain.Equip.ValueObjects;

namespace RFLOT.Gateway.Monitoring.Models;

public class StartMonitoringResult
{
    public string Space { get; set; }
    public Status Status { get; set; }
}