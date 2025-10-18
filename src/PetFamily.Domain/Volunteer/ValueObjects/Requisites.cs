using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Requisites(string Title, string Description)
{
    public static Result<Requisites, Error> Create(string title, string description)
    {
        if(string.IsNullOrWhiteSpace(title))
            return Errors.General.ValueIsInvalid("Title");
        
        if(string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("Description");
        
        return new Requisites(title, description);
    }
}