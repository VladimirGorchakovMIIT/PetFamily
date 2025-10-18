using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record FullName(string Name, string Surname, string Patronymic)
{
    public static Result<FullName, Error> Create(string name, string surname, string patronymic)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Name");
        
        if(string.IsNullOrWhiteSpace(surname))
            return Errors.General.ValueIsInvalid("Surname");
        
        if(string.IsNullOrWhiteSpace(patronymic))
            return Errors.General.ValueIsInvalid("Patronymic");
        
        return new FullName(name, surname, patronymic);
    }
}