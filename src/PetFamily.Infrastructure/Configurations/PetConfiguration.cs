using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("type");
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("status");
        builder.Property(x => x.Breed).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("breed");
        builder.Property(x => x.IsNeutered).IsRequired().HasColumnName("ss_neutered");
        builder.Property(x => x.IsVaccinated).IsRequired().HasColumnName("ss_vaccinated");
        builder.Property(x => x.BirthDate).HasColumnName("birth_date");
        builder.Property(x => x.DateCreation).HasColumnName("date_creation");

        builder.ComplexProperty(x => x.Nickname, tb =>
        {
            tb.IsRequired();
            tb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("pet_nickname");
        });

        builder.ComplexProperty(x => x.Description, tb =>
        {
            tb.IsRequired();
            tb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_DESCRIPTION_LEGHT).HasColumnName("pet_description");
        });

        builder.ComplexProperty(x => x.Specifications, tb =>
        {
            tb.IsRequired();

            tb.Property(x => x.Height).IsRequired().HasColumnName("specification_height");
            tb.Property(x => x.Weight).IsRequired().HasColumnName("specification_weight");
            tb.Property(x => x.Color).IsRequired().HasConversion<string>().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("specification_color");
            tb.Property(x => x.HealthInformation).IsRequired().HasMaxLength(Constants.MAX_DESCRIPTION_LEGHT).HasColumnName("specification_health_information");
        });

        builder.ComplexProperty(x => x.PhoneNumber, tb =>
        {
            tb.IsRequired();
            tb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_PHONE_NUMBER).HasColumnName("phone_number_value");
        });

        builder.ComplexProperty(x => x.SharedLinks, tb =>
        {
            tb.IsRequired();

            tb.Property(x => x.BreedId).IsRequired().HasColumnName("shared_links_breed_id");
            tb.Property(x => x.SpeciesId).IsRequired().HasColumnName("shared_links_species_id");
        });
    }
}