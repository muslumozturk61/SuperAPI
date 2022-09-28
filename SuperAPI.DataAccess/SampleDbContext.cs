using SuperAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace SuperAPI.DataAccess
{

    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Account>? Accounts { get; set; }
    }
}
