using CSharpFunctionalExtensions;
using PetFamily.Domain.Species.ValueObjects;

namespace PetFamily.Domain.Species;

public sealed class Breed : Entity<Guid>
{
    #region Constructors

    public Breed()
    {
    }

    private Breed(Guid id, Title title) : base(id)
    {
        Id = id;
        Title = title;
    }

    #endregion
    
    public override Guid Id { get; protected set; }

    public Title? Title { get; private set; }

    public static Result<Breed> Create(Guid id, Title title)
    {
        return new Breed(id, title);
    }
}