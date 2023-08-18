using CustomerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class ApiDbContext : DbContext
    {
       
        
            public DbSet<Customer> Customers{ get; set; }
         public DbSet<Vehicle> vihicles { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CustomersApidb;Trusted_Connection=True;");
            }
        }

    }


