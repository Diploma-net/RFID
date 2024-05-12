using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFLOT.Domain.Report.ValueObjects;

namespace RFLOT.Infrastructure.Report.EntityConfigurations;

public class ZoneConfiguration : IEntityTypeConfiguration<ZoneReport>
{
    public void Configure(EntityTypeBuilder<ZoneReport> entityTypeBuilder)
    {
        entityTypeBuilder.Property(e => e.Checkers).HasColumnType("jsonb");
        entityTypeBuilder.Property(e => e.EquipReports).HasColumnType("jsonb");
    }
}