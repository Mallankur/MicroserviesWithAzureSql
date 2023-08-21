using Microsoft.EntityFrameworkCore;
using ReservationApi.Model;

namespace ReservationApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReservationApiDb;Trusted_Connection=True;");
        }
    }
}

