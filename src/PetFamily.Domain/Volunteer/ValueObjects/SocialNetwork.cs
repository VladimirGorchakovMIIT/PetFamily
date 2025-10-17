using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

[Owned]
public record SocialNetwork(string Title, string Url)
{
    public static Result<SocialNetwork, string> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(link))
            return "You must provide a title or link";

        return new SocialNetwork(title, link);
    }
}