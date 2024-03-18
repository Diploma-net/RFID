using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFLOT.Domain.Equip;

namespace RFLOT.Infrastructure.Contexts.EntityConfigurations;

public class EquipConfiguration: IEntityTypeConfiguration<Equip>
{
    public void Configure(EntityTypeBuilder<Equip> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
    }
}