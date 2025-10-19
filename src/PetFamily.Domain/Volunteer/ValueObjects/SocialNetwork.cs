using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record SocialNetwork(string Title, string Url)
{
    public static Result<SocialNetwork, Error> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid("Title");
        
        if (string.IsNullOrWhiteSpace(link))
            return Errors.General.ValueIsInvalid("Link");

        return new SocialNetwork(title, link);
    }
}