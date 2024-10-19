using Microsoft.AspNetCore.Mvc;
using PostgresApi.Models;
using PostgresApi.Services;

namespace PostgresApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(ClientService clientService) : ControllerBase
{
    [HttpGet("{id}")]
    public Client Get(string id)
    {
        return clientService.Get(id);
    }
    
    [HttpGet]
    public IEnumerable<Client> List()
    {
        return clientService.List();
    }
}