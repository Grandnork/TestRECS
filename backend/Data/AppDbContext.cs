using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Database tables
    public DbSet<Person> People { get; set; }

    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
            Definindo a relação entre a tabela pessoas e transações, 
            uma pessoa terá varias transações enquanto cada transação 
            fará referência apenas a uma pessoa.
        */
        modelBuilder.Entity<Person>()
            .HasMany(person => person.Transactions)
            .WithOne(transaction => transaction.Person)
            .HasForeignKey(transaction => transaction.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}