using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Nickname(string Value)
{
    public static Result<Nickname, string> Create(string nickname)
    {
        if(string.IsNullOrWhiteSpace(nickname))
            return "Nickname cannot be null or empty.";
        
        return new Nickname(nickname);
    }
}