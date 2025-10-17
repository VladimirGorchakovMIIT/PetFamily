using CSharpFunctionalExtensions;
using PetFamily.Domain.Species.ValueObjects;

namespace PetFamily.Domain.Species;

public sealed class Breed : Entity<Guid>
{
    public Breed(){}

    private Breed(Guid id, Title title) : base(id)
    {
        Id = id;
        Title = title;
    }
    
    public override Guid Id { get; protected set; }
    
    public Title? Title { get; private set; }

    public static Result<Breed> Create(Guid id, Title title)
    {
        return new Breed(id, title);
    }
}