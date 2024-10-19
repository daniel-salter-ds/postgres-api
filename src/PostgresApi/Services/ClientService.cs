using PostgresApi.Models;

namespace PostgresApi.Services;

public class ClientService
{
    public IEnumerable<Client> List()
    {
        return [
            new Client("Id1", "Name"),
            new Client("Id2", "Different Name")
        ];
    }
}