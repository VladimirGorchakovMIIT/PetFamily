using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.ComplexProperty(x => x.Title, tb =>
        {
            tb.IsRequired();
            tb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("title");
        });
    }
}