using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<Person> Pessoas { get; set; }
    public DbSet<Contract> Contratos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>(table => {  
            table.HasKey(e => e.Id);  // Na tabela pessoa terá uma chave  (e = pessoas)
            table 
            .HasMany(e => e.contratos)  // A clase pessoa poderá ter varios contratos
            .WithOne()  // Para cada um contrato terá um chave estrangeira
            .HasForeignKey(c => c.PersonId);  // Chave estrangeira 

        });

        builder.Entity<Contract>(table => {
            table.HasKey(e => e.Id);

        });
    }

}