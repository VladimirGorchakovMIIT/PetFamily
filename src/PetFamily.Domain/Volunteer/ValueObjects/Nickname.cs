using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Nickname(string Value)
{
    public static Result<Nickname, Error> Create(string nickname)
    {
        if(string.IsNullOrWhiteSpace(nickname))
            return Errors.General.ValueIsInvalid("Nickname");
        
        return new Nickname(nickname);
    }
}