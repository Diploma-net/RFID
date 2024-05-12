namespace RFLOT.Gateway.Monitoring.Models;

public class ZoneConnection
{
    public ZoneConnection(Guid idReport, Guid idZone, Guid idUser)
    {
        IdReport = idReport;
        IdZone = idZone;
        IdUser = idUser;
    }

    public Guid IdReport { get; }
    public Guid IdZone { get; }
    public Guid IdUser { get; }
}