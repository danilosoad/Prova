using Microsoft.EntityFrameworkCore;
using Prova.Core.Entity.Moeda;

namespace Prova.Infra.Data.DataConxtext
{
    public class DataContext : DbContext
    {
        public DbSet<Moeda> Moedas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MoedaDb");
        }
    }
}