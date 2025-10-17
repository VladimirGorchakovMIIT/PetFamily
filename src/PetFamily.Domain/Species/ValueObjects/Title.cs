using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Species.ValueObjects;

[Owned]
public record Title(string Value)
{
    public static Result<Title, string> Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "Title cannot be null or empty.";

        return new Title(title);
    }
}