using PostgresApi.Models;

namespace PostgresApi.Services;

public class ClientService
{
    public Client Get(string id)
    {
        return new Client(id, "Name");
    }
    public IEnumerable<Client> List()
    {
        return [
            new Client("Id1", "Name"),
            new Client("Id2", "Different Name")
        ];
    }
}