using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RFLOT.Infrastructure.Zone.Configurations;

public class ZoneConfiguration : IEntityTypeConfiguration<Domain.Zone.Zone>
{
    public void Configure(EntityTypeBuilder<Domain.Zone.Zone> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
    }
}