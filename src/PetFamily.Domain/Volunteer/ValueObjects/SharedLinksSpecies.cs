using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record SharedLinksSpecies(Guid SpeciesId, Guid BreedId)
{
    public static Result<SharedLinksSpecies, Error> Create(Guid speciesId, Guid breedId)
    {
        if (speciesId == Guid.Empty)
            return Errors.General.NotFounded(speciesId);
        
        if (breedId == Guid.Empty)
            return Errors.General.NotFounded(breedId);
        
        return new SharedLinksSpecies(speciesId, breedId);
    }
}