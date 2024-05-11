namespace RFLOT.Gateway.Monitoring.Models;

public class NewConnection
{
    public NewConnection(Guid idReport, Guid idUser)
    {
        IdReport = idReport;
        IdUser = idUser;
    }

    public Guid IdReport { get; }
    public Guid IdUser { get; }
}