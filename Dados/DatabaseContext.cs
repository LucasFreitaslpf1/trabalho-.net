using Microsoft.EntityFrameworkCore;

namespace Dados;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Instrumento> Instrumento { get; set; }
    public DbSet<Musica> Musica { get; set; }

    public DbSet<Sample> Sample { get; set; }

    public DbSet<Postagem> Postagem { get; set; }
}
