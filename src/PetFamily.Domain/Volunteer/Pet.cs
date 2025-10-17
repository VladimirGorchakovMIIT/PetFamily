using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer.ValueObjects;

namespace PetFamily.Domain.Volunteer;

public sealed class Pet : Entity<Guid>
{
    public Pet() { }

    private Pet(Guid id, string nickname, PetType type, Description? description, Specifications? specifications, string breed, string phoneNumber, bool isNeutered, DateTime birthDate, bool isVaccinated, bool isFoundedHouse, Status status, DateTime dateCreation, SharedLinksSpecies? sharedLinks)
    {
        Id = id;
        Nickname = nickname;
        Type = type;
        Description = description;
        Specifications = specifications;
        Breed = breed;
        PhoneNumber = phoneNumber;
        IsNeutered = isNeutered;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        IsFoundedHouse = isFoundedHouse;
        Status = status;
        DateCreation = dateCreation;
        SharedLinks = sharedLinks;
    }

    public override Guid Id { get; protected set; }

    public string Nickname { get; private set; }

    public PetType Type { get; private set; }

    public Description? Description { get; private set; }

    public Specifications? Specifications { get; private set; }

    public string Breed { get; private set; } = default!;

    public string PhoneNumber { get; private set; } = default!;

    public bool IsNeutered { get; private set; }

    public DateTime BirthDate { get; private set; }

    public bool IsVaccinated { get; private set; }

    public bool IsFoundedHouse { get; private set; }

    public Status Status { get; private set; }

    public DateTime DateCreation { get; private set; }

    public SharedLinksSpecies? SharedLinks { get; private set; }

    public static Result<Pet> Create(Guid id, string nickname, PetType type, Description? description, Specifications? specifications, string breed, string phoneNumber, bool isNeutered, DateTime birthDate, bool isVaccinated, bool isFoundedHouse, Status status, DateTime dateCreation, SharedLinksSpecies? sharedLinks)
    {
        return new Pet(id, nickname, type, description, specifications, breed, phoneNumber, isNeutered, birthDate, isVaccinated, isFoundedHouse, status, dateCreation, sharedLinks);
    }
}