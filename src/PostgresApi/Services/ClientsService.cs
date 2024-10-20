using Microsoft.EntityFrameworkCore;
using PostgresApi.Data;
using PostgresApi.Models;

namespace PostgresApi.Services;

public class ClientsService(AppDbContext context)
{
    /// <summary>
    /// Get Client
    /// </summary>
    /// <remarks>
    /// Get Client with specific Id
    /// </remarks>
    /// <param name="id">The Id which uniquely identifies the Client</param>
    /// <returns>A structure with the queried data or failure</returns>
    public Client? Get(string id)
    {
        return context.Clients.FirstOrDefault(c => c.Id == id);
    }
    
    /// <summary>
    /// List the set of Clients
    /// </summary>
    /// <remarks>
    /// List the set of Clients
    /// </remarks>
    /// <param name="asAt">The asAt datetime at which to list the Clients. Defaults to latest if not specified.</param>
    /// <returns>A structure with the queried data or failure</returns>
    public IEnumerable<Client> List()
    {
        return context.Clients.ToList();
    }

    public Client Upsert(Client client)
    {
        var existingClient = context.Clients.AsNoTracking().FirstOrDefault(c => c.Id == client.Id);

        if (existingClient == null)
        {
            context.Clients.Add(client);
        }
        else
        {
            context.Clients.Update(client);
        }
        
        context.SaveChanges();
        return client;
    }
    

    public bool Delete(string id)
    {
        var existingClient = context.Clients.FirstOrDefault(c => c.Id == id);

        if (existingClient == null)
        {
            return false;
        }
        
        context.Clients.Remove(existingClient);
        context.SaveChanges();
        return true;
    }
}