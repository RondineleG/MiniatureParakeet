using Microsoft.EntityFrameworkCore;
using MiniatureParakeet.Core.Entities;

namespace MiniatureParakeet.Infrastructure
{
    public class RegisterDataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Terminal> Terminals { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-54-196-33-23.compute-1.amazonaws.com;Port=5432;Database=d9qjf3abo27j0;User Id=tnotvljitntyem;Password=b5b987eda20b0f97c970dcb529877c2c75f17db3349b551ee3c715168545cd54;SSL Mode=Require;Trust Server Certificate=true");
        }

    }
}
