using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.HasMany(x => x.Pets).WithOne().HasForeignKey("volunteer_id").OnDelete(DeleteBehavior.Cascade);
        builder.ComplexProperty(x => x.FullName, tb =>
        {
            tb.IsRequired();
            tb.Property(x => x.Name).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("full_name_name");
            tb.Property(x => x.Surname).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("full_name_surname");
            tb.Property(x => x.Patronymic).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("full_name_patronymic");
        });

        builder.ComplexProperty(x => x.Description, pb =>
        {
            pb.IsRequired();
            pb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_DESCRIPTION_LEGHT).HasColumnName("description_value");
        });

        builder.ComplexProperty(x => x.PhoneNumber, pb =>
        {
            pb.IsRequired();
            pb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_PHONE_NUMBER).HasColumnName("phone_number");
        });

        builder.ComplexProperty(x => x.Requisites, pb =>
        {
            pb.IsRequired();
            pb.Property(x => x.Title).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("requisites_title");
            pb.Property(x => x.Description).IsRequired().HasMaxLength(Constants.MAX_DESCRIPTION_LEGHT).HasColumnName("requisites_description");;
        });

        builder.OwnsOne(x => x.VolunteerDetails, pb =>
        {
            pb.ToJson();

            pb.OwnsMany(x => x.SocialNetworks, vd =>
            {
                vd.Property(x => x.Title).IsRequired().HasMaxLength(Constants.MAX_LENGHT_STANDART).HasColumnName("social_network_title");
                vd.Property(x => x.Url).IsRequired().HasMaxLength(Constants.MAX_URL_LENGHT).HasColumnName("social_network_url");
            });
        });
    }
}