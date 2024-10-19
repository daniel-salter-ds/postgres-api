using PostgresApi.Models;

namespace PostgresApi.Services;

public class ClientService
{
    public Client? Get(string id)
    {
        // Simulate a lookup that could fail
        if (id == "Id1")
        {
            return new Client(id, "Name");
        }
        return null; // Return null if not found
    }
    public IEnumerable<Client> List()
    {
        return [
            new Client("Id1", "Name"),
            new Client("Id2", "Different Name")
        ];
    }

    public Client Upsert(Client client)
    {
        return client;
    }

    public bool Delete(string id)
    {
        // Simulate deletion logic
        return id == "Id1"; // Return true for success, false otherwise
    }
}