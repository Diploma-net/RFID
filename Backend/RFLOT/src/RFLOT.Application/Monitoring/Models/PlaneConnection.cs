namespace RFLOT.Gateway.Monitoring.Models;

public class PlaneConnection
{
    public PlaneConnection(Guid idReport, Guid idUser)
    {
        IdReport = idReport;
        IdUser = idUser;
    }

    public Guid IdReport { get; }
    public Guid IdUser { get; }
}