using System.Net;
using Microsoft.AspNetCore.Mvc;
using Profil.DBContext;
using Profil.Repository;

namespace Profil.Controllers;


[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    
    private readonly ILogger<PersonController> _logger;
    private readonly PersonRepository _personRepository;

    public PersonController(ILogger<PersonController> logger, PersonContext context)
    {
        _logger = logger;
        _personRepository = new PersonRepository(context);
    }

    [HttpPost(Name = "AddPerson")]
    public async Task<ActionResult<Person>> CreatePerson(Person person)
    {
        try
        {
            if (person == null)
                return BadRequest();

            var createdPerson = await _personRepository.AddPerson(person);
            return Ok();

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
        }
    }
    
    
}