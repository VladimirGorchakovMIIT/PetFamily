using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Requisites(string Title, string Description)
{
    public static Result<Requisites, string> Create(string title, string description)
    {
        if(string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            return "You must provide a title or description";
        
        return new Requisites(title, description);
    }
}