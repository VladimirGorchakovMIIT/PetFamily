using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Species.ValueObjects;

namespace PetFamily.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SpeciesController : ControllerBase
{
    [HttpGet]
    public ActionResult<Result<Species, Error>> Get()
    {
        var dog = Title.Create("Собака");
        
        if (dog.IsFailure)
            return BadRequest(dog.Error);
        
        var species = Species.Create(Guid.NewGuid(), dog.Value);
        
        if(species.IsFailure)
            return BadRequest(species.Error);
        
        return Ok(species.Value);
    }
}