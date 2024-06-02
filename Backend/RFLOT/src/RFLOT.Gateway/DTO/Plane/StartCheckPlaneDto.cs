using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Gateway.DTO.Plane;

public class StartCheckPlaneDto
{
    public string IdPlane { get; set; }
    public Guid IdUser { get; set; }
    public ReportType TypeCheck { get; set; }
}