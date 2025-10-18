using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Specifications(float Height, float Weight, Color Color, string HealthInformation)
{
    public static Result<Specifications, string> Create(float height, float weight, Color color, string healthInformation)
    {
        if(weight <= 0 || height <= 0)
            return "Weight or height must be greater than 0";
        
        if(string.IsNullOrWhiteSpace(healthInformation))
            return "Health information cannot be null or empty";

        return new Specifications(height, weight, color, healthInformation);
    }
}