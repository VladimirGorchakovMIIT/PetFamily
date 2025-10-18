using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer.ValueObjects;

namespace PetFamily.Domain.Volunteer;

public sealed class Volunteer : Entity<Guid>
{
    private readonly List<Pet> _pets = new();
    
    public Volunteer(){ }

    private Volunteer(Guid id, FullName fullName, Description description, string phoneNumber, Requisites requisites, VolunteerDetails volunteerDetails) : base(id)
    {
        Id = id;
        FullName = fullName;
        Description = description;
        PhoneNumber = phoneNumber;
        Requisites = requisites;
        VolunteerDetails = volunteerDetails;
    }

    public override Guid Id { get; protected set; }

    public FullName FullName { get; private set; }

    public Description? Description { get; private set; }

    public string PhoneNumber { get; private set; }
    
    public Requisites? Requisites { get; private set; }

    public VolunteerDetails? VolunteerDetails { get; private set; }

    public IReadOnlyList<Pet> Pets => _pets;
    
    public void AddPet(Pet pet) => _pets.Add(pet);

    public int AmountPetsFoundedHouse() => Pets.Count(x => x.Status == Status.FoundedHouse);
    
    public int AmountPetsLookingHouse() => Pets.Count(x => x.Status == Status.LookingHome);
    
    public int AmountPetsNeedTreatment() => Pets.Count(x => x.Status == Status.NeedTreatment);

    public static Result<Volunteer> Create(Guid id, FullName fullName, Description description, string phoneNumber, Requisites requisites, VolunteerDetails volunteerDetails)
    {
        return new Volunteer(id, fullName, description, phoneNumber, requisites, volunteerDetails);
    }
}