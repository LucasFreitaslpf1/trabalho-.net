using Microsoft.EntityFrameworkCore;

namespace Dados;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    { }

    public DbSet<Usuario> Usuario { get; set; }

}
