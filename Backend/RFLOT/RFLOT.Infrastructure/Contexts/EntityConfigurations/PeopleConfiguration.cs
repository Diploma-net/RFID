using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFLOT.Domain.People;

namespace RFLOT.Infrastructure.Contexts.EntityConfigurations;

public class PeopleConfiguration :  IEntityTypeConfiguration<People>
{
    public void Configure(EntityTypeBuilder<People> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.Id);
    }
}
