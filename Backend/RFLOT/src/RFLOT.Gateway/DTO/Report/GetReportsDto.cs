using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Gateway.DTO.Report;

    public class GetReportsDto
    {
        public bool ReportResult { get; set; }
        public string? PlaneName { get; set; }
        public DateOnly? ReportDate { get; set; }
        public ReportType? ReportType { get; set; }
    }