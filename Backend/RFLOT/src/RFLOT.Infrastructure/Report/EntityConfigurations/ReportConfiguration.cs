using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Infrastructure.Report.EntityConfigurations;

public class ReportConfiguration : IEntityTypeConfiguration<Domain.Report.Report>
{
    public void Configure(EntityTypeBuilder<Domain.Report.Report> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder.Property(e => e.ZoneReports).HasColumnType("jsonb").HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<ZoneReport>>(v));
    }
}