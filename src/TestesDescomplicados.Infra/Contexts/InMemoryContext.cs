using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestesDescomplicados.Domain.Aggregates.SoftwareAggregate;
using TestesDescomplicados.Domain.Aggregates.UsuarioAggregate;

namespace TestesDescomplicados.Infra.Contexts;

public class InMemoryContext(DbContextOptions<InMemoryContext> options) 
    : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TestesDescomplicados");
    }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Software> Softwares { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nome).IsRequired(false);
            entity.Property(e => e.Email).IsRequired(false);
            entity.Property(e => e.TipoUsuario).IsRequired();
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NomeCliente).IsRequired(false);
        });
    }
}
