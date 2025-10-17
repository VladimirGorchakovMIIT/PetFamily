using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

[Owned]
public record FullName(string Name, string Surname, string Patronymic)
{
    public static Result<FullName, string> Create(string name, string surname, string patronymic)
    {
        if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(patronymic))
            return "You must provide a name, surname or last name";
        
        return new FullName(name, surname, patronymic);
    }
}