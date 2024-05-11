using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RFLOT.Infrastructure.Plane.Configurations;

public class PlaneConfiguration : IEntityTypeConfiguration<Domain.Plane.Plane>
{
    public void Configure(EntityTypeBuilder<Domain.Plane.Plane> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
    }
}