using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record PhoneNumber(string Value)
{
    public static Result<PhoneNumber, Error> Create(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Errors.General.ValueIsInvalid("Phone Number");

        var cleanedNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");
        
        if(Regex.IsMatch(cleanedNumber, @"^(\+7|8)\d{10}$"))
            return Errors.General.ValueIsInvalid("Phone Number Incorrect Format");
        
        return new PhoneNumber(cleanedNumber);
    }
}