using Microsoft.EntityFrameworkCore;
using PostgresApi.Data;
using PostgresApi.Models;

namespace PostgresApi.Services;

public class ClientsService(AppDbContext context)
{
    public Client? Get(string id)
    {
        return context.Clients.FirstOrDefault(c => c.Id == id);
    }
    
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