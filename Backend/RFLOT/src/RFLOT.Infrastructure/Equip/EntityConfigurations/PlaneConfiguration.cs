using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFLOT.Domain.Plane;

namespace RFLOT.Infrastructure.Equip.EntityConfigurations;

public class PlaneConfiguration :  IEntityTypeConfiguration<Plane>
{
    public void Configure(EntityTypeBuilder<Plane> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
        entityTypeBuilder.Property(e => e.Zones).HasColumnType("jsonb");
    }
}