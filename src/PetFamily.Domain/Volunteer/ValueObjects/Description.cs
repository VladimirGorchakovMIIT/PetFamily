using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Description(string Value)
{
    public static Result<Description, string> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return "Description cannot be null or empty.";
        
        return new Description(description);
    }
}