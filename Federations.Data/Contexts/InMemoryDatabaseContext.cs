using Federations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Federations.Data.Contexts
{
    public class InMemoryDatabaseContext : DbContext
    {
        public DbSet<FederationModel> Federations { get; set; }

        public InMemoryDatabaseContext(DbContextOptions<InMemoryDatabaseContext> options)
            : base(options)
        {
        }
    }
}
