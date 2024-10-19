using Microsoft.AspNetCore.Mvc;
using PostgresApi.Models;
using PostgresApi.Services;

namespace PostgresApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(ClientService clientService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Client>> List()
    {
        var clients = clientService.List();
        return Ok(clients);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Client> Get(string id)
    {
        var client = clientService.Get(id);
        return Ok(client);
    }

    [HttpPost]
    public ActionResult<Client> Upsert([FromBody] Client client)
    {
        var clientResult = clientService.Upsert(client);
        return Ok(clientResult);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var success = clientService.Delete(id);
        if (!success) return BadRequest();
        return Ok();
    }
}