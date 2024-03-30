using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RFLOT.Infrastructure.Equip.EntityConfigurations;

public class EquipConfiguration: IEntityTypeConfiguration<Domain.Equip.Equip>
{
    public void Configure(EntityTypeBuilder<Domain.Equip.Equip> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
    }
}