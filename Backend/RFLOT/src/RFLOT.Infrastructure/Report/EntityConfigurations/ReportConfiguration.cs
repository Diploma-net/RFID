using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RFLOT.Infrastructure.Report.EntityConfigurations;

public class ReportConfiguration : IEntityTypeConfiguration<Domain.Report.Report>
{
    public void Configure(EntityTypeBuilder<Domain.Report.Report> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder.Property(e => e.EquipReports).HasColumnType("jsonb");
    }
}