using Microsoft.EntityFrameworkCore;
using PostgresApi.Models;

namespace PostgresApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet represents a collection of entities that can be queried or saved.
        public DbSet<Client> Clients { get; set; }

        // You can override OnModelCreating to configure model properties further.
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}