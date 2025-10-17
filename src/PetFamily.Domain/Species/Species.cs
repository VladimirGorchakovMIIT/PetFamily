using CSharpFunctionalExtensions;
using PetFamily.Domain.Species.ValueObjects;

namespace PetFamily.Domain.Species;

public sealed class Species : Entity<Guid>
{
    private List<Breed> _breeds = [];

    public Species() { }

    private Species(Guid id, Title title) : base(id)
    {
        Id = id;
        Title = title;
    }

    public override Guid Id { get; protected set; }

    public Title? Title { get; private set; }

    public IReadOnlyList<Breed> Breeds => _breeds;

    public void AddBreed(Breed breed) => _breeds.Add(breed);

    public static Result<Species> Create(Guid id, Title title)
    {
        return new Species(id, title);
    }
}