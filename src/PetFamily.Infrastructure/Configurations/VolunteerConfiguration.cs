using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteer");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        
        builder.HasMany(x => x.Pets).WithOne().HasForeignKey("volunteer_id").OnDelete(DeleteBehavior.Cascade);
        
        builder.OwnsOne(x => x.FullName, pb =>
        {

            pb.Property(x => x.Name).IsRequired().HasMaxLength(Constants.MAX_LENGHT);
            pb.Property(x => x.Surname).IsRequired().HasMaxLength(Constants.MAX_LENGHT);
            pb.Property(x => x.Patronymic).IsRequired().HasMaxLength(Constants.MAX_LENGHT);
        });

        builder.OwnsOne(x => x.Description, pb =>
        {
            pb.Property(x => x.Value).IsRequired().HasMaxLength(Constants.MAX_DESCRIPTION_LEGHT);
        });

        builder.OwnsOne(x => x.Requisites, pb =>
        {
            pb.Property(x => x.Title).IsRequired().HasMaxLength(Constants.MAX_LENGHT);
            pb.Property(x => x.Description).IsRequired().HasMaxLength(Constants.MAX_DESCRIPTION_LEGHT);
        });

        builder.OwnsOne(x => x.VolunteerDetails, pb =>
        {
            pb.ToJson();

            pb.OwnsMany(x => x.SocialNetworks, vd =>
            {
                vd.Property(x => x.Title).IsRequired().HasMaxLength(Constants.MAX_LENGHT);
                vd.Property(x => x.Url).IsRequired().HasMaxLength(Constants.MAX_URL_LENGHT);
            });
        });
    }
}