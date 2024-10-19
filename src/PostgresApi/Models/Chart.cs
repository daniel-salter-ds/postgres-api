namespace PostgresApi.Models;

public record Chart(string Id, string Title, int[] Data, Report Report);