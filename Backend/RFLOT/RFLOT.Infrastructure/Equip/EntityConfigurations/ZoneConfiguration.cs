using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFLOT.Domain.Zone;

namespace RFLOT.Infrastructure.Contexts.EntityConfigurations;

public class ZoneConfiguration:  IEntityTypeConfiguration<Zone>
{
    public void Configure(EntityTypeBuilder<Zone> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
    }
}