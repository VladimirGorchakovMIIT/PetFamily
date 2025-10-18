using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record PhoneNumber(string Value)
{
    public static Result<PhoneNumber, String> Create(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return "Phone number cannot be null or empty.";

        var cleanedNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");
        
        if(Regex.IsMatch(cleanedNumber, @"^(\+7|8)\d{10}$"))
            return "Incorrect phone number.";
        
        return new PhoneNumber(cleanedNumber);
    }
}