using Microsoft.EntityFrameworkCore;
using Vehicele.Model;

namespace Vehicele.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Vihicle> vihicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=vehiclesApidb;Trusted_Connection=True;");
        }
    }

}
