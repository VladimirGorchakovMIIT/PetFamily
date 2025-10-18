using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace PetFamily.Domain.Volunteer.ValueObjects;

public record SharedLinksSpecies(Guid SpeciesId, Guid BreedId)
{
    public static Result<SharedLinksSpecies, string> Create(Guid speciesId, Guid breedId)
    {
        if (speciesId == Guid.Empty)
            return "Species id cannot be empty";
        
        if (breedId == Guid.Empty)
            return "Breed id cannot be empty";
        
        return new SharedLinksSpecies(speciesId, breedId);
    }
}