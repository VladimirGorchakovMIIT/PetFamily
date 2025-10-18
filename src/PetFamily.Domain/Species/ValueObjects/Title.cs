using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species.ValueObjects;

public record Title(string Value)
{
    public static Result<Title, Error> Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid("Title Species");

        return new Title(title);
    }
}