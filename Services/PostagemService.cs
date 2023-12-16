using Dados;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class PostagemService
{
    protected readonly DatabaseContext DbContext;

    public PostagemService(DatabaseContext db)
    {
        DbContext = db;
    }

    public List<Postagem> getAllPostagem()
    {
        return DbContext.Postagem.OrderByDescending(x => x.datahora).ToList();
    }

    public Task InsertPostagem(Postagem user)
    {
        DbContext.Postagem.Add(user);
        return DbContext.SaveChangesAsync();
    }

    public Task EditPostagem(int postId)
    {
        Postagem Postagem = new();
        return DbContext.Postagem.FirstOrDefaultAsync(u => Postagem.id == postId);
    }

    public Task UpdatePostagem(Postagem Postagem)
    {
        var post = DbContext.Postagem.FirstOrDefault(u => u.id == Postagem.id);

        post.id = Postagem.id;
        post.datahora = Postagem.datahora;
        post.texto = Postagem.texto;

        return DbContext.SaveChangesAsync();
    }

    public bool DeletePostagem(Postagem Postagem)
    {
        var post = DbContext.Postagem.FirstOrDefault(u => u.id == Postagem.id);
        if (post != null)
        {
            DbContext.Remove(post);
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }
}
