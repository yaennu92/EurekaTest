using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace Profil.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase {
    private readonly ILogger _logger;
    DiscoveryHttpClientHandler _handler;
    public ValuesController(ILogger<ValuesController> logger, IDiscoveryClient client) {
        _logger = logger;
        _handler = new DiscoveryHttpClientHandler(client);
    }

    // GET api/values
    [HttpGet]
    public async Task<string> Get() {
        var client = new HttpClient(_handler, false);
        return await client.GetStringAsync("http://EurekaRegisterExample/api/values");
    }
}