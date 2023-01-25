using System.Net;
using Microsoft.AspNetCore.Mvc;
using Profil.DBContext;
using Profil.Repository;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace Profil.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly PersonRepository _personRepository;
    private readonly PersonContext _context;
    private readonly HttpClient _httpClient;
    private readonly DiscoveryHttpClientHandler _handler;

    public PersonController(ILogger<PersonController> logger, PersonContext context, IDiscoveryClient client)
    {
        _logger = logger;
        _personRepository = new PersonRepository(context);
        _context = context;
        _handler = new DiscoveryHttpClientHandler(client);

        _httpClient = new HttpClient(_handler, false);
    }

    [Route("[action]")]
    public async Task<ActionResult<Person>> CreatePerson(Person person)
    {
        try
        {
            if (person == null)
                return BadRequest();
            await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                var createdPerson = _personRepository.AddPerson(person);
                // var  result =await _httpClient.PostAsJsonAsync("http://AddressExample/WeatherForecast/AddAddress", new
                // {
                //     id = createdPerson.Id,
                //     street = "string",
                //     zip = "string",
                //     city = "string"
                // });
                // if (result.StatusCode != HttpStatusCode.OK)
                //     throw new Exception("blubb");
                
                await dbContextTransaction.CommitAsync();
            }

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
        }
    }
}