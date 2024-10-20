using Microsoft.AspNetCore.Mvc;
using PostgresApi.Models;
using PostgresApi.Services;

namespace PostgresApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(ClientsService clientsService) : ControllerBase
{
    /// <summary>
    /// List the set of Clients
    /// </summary>
    /// <remarks>
    /// List the set of Clients
    /// </remarks>
    /// <returns>The requested Clients</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Client>> List()
    {
        var clients = clientsService.List();
        return Ok(clients);
    }
    
    /// <summary>
    /// Get Client
    /// </summary>
    /// <remarks>
    /// Get Client with specific Id
    /// </remarks>
    /// <param name="id">The Id which uniquely identifies the Client</param>
    /// <returns>The successfully retrieved Client or any failure</returns>
    [HttpGet("{id}")]
    public ActionResult<Client> Get(string id)
    {
        var client = clientsService.Get(id);
        if (client == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(client); // Return 200 with client data
    }

    /// <summary>
    /// Upsert Client
    /// </summary>
    /// <remarks>
    /// Update or insert Client. An item will be updated if it already exists and inserted if it does not.
    /// </remarks>
    /// <param name="client">The Client to update or insert</param>
    /// <returns>The successfully updated or inserted Client or any failure</returns>
    [HttpPost]
    public ActionResult<Client> Upsert([FromBody] Client client)
    {
        var clientResult = clientsService.Upsert(client);
        return Ok(clientResult);
    }

    /// <summary>
    /// Delete Client
    /// </summary>
    /// <remarks>
    /// Delete Client with specific Id
    /// </remarks>
    /// <param name="id">The Id which uniquely identifies the Client</param>
    /// <returns>Success or failure of deletion</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var success = clientsService.Delete(id);
        if (!success) return NotFound();
        return Ok();
    }
}