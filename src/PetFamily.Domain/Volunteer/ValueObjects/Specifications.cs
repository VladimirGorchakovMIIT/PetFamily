using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record Specifications(float Height, float Weight, Color Color, string HealthInformation)
{
    public static Result<Specifications, Error> Create(float height, float weight, Color color, string healthInformation)
    {
        if (weight <= 0)
            return Errors.General.InCorrectAmount(weight);

        if (height <= 0)
            return Errors.General.InCorrectAmount(height);

        if (string.IsNullOrWhiteSpace(healthInformation))
            return Errors.General.ValueIsInvalid("Health Information");

        return new Specifications(height, weight, color, healthInformation);
    }
}