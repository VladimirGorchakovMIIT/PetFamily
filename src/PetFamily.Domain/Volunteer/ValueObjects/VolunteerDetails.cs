using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

[Owned]
public record VolunteerDetails
{
    public List<SocialNetwork> SocialNetworks { get; } = [];
}