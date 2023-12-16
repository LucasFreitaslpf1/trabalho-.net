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
        Usuario usuario = new();
        return DbContext.Usuario.FirstOrDefaultAsync(u => u.id == userId);
    }

    public Task UpdateUsuario(Usuario usuario)
    {
        var user = DbContext.Usuario.FirstOrDefault(u => u.id == usuario.id);

        user.id = usuario.id;
        user.nome = usuario.nome;
        return DbContext.SaveChangesAsync();
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

    public async Task<List<Usuario>> PesquisarUsuariosAsync(string termoPesquisa)
    {
        return await DbContext.Usuario
            .Where(u => EF.Functions.ILike(u.nome, $"%{termoPesquisa}%"))
            .ToListAsync();
    }
    public Usuario getUsuarioByNome(string nome)
    {
        var user = DbContext.Usuario.FirstOrDefault(u => u.nome == nome);
        return user;
    }

    public Usuario getUsuarioById(int id)
    {
        var user = DbContext.Usuario.FirstOrDefault(u => u.id == id);
        return user;
    }
}
