using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record VolunteerDetails
{
    public List<SocialNetwork> SocialNetworks { get; } = [];
}