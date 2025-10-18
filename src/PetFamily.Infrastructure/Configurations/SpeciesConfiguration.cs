using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Species.ValueObjects;

namespace PetFamily.Infrastructure.Configurations;

[Owned]
public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.HasMany(x => x.Breeds).WithOne().HasForeignKey("species_id").OnDelete(DeleteBehavior.Cascade);
        builder.ComplexProperty(x => x.Title, tb =>
        {
            tb.IsRequired();
            tb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_TITLE_LEGHT).HasColumnName("title");
        });
    }
}