using Dados;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class UsuarioService
{
    protected readonly DatabaseContext DbContext;

    public UsuarioService(DatabaseContext db)
    {
        DbContext = db;
    }

    public List<Usuario> getAllUsuario()
    {
        return DbContext.Usuario.ToList();
    }

    public Task InsertUsuario(Usuario user)
    {
        DbContext.Usuario.Add(user);
        return DbContext.SaveChangesAsync();
    }

    public Task EditUsuario(int userId)
    {
        Usuario usuario = new Usuario();
        return DbContext.Usuario.FirstOrDefaultAsync(u => u.id == userId);
    }

    public bool UpdateUsuario(Usuario usuario)
    {
        var user = DbContext.Usuario.FirstOrDefault(u => u.id == usuario.id);
        if (user != null)
        {
            user.id = usuario.id;
            user.nome = usuario.nome;
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool DeleteUsuario(Usuario usuario)
    {
        var user = DbContext.Usuario.FirstOrDefault(u => u.id == usuario.id);
        if (user != null)
        {
            DbContext.Remove(user);
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }
}
