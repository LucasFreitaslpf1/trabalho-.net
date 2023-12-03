using Dados;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class MusicaService
{
    protected readonly DatabaseContext DbContext;

    public MusicaService(DatabaseContext db)
    {
        DbContext = db;
    }

    public List<Musica> getAllMusica()
    {
        return DbContext.Musica.ToList();
    }

    public Task InsertMusica(Musica mus)
    {
        DbContext.Musica.Add(mus);
        return DbContext.SaveChangesAsync();
    }

    public Task EditMusica(int musId)
    {
        Musica musica = new Musica();
        return DbContext.Musica.FirstOrDefaultAsync(i => i.id == musId);
    }

    public bool UpdateMusica(Musica musica)
    {
        var mus = DbContext.Musica.FirstOrDefault(i => i.id == musica.id);
        if (mus != null)
        {
            mus.id = musica.id;
            mus.titulo = musica.titulo;
            mus.autor = musica.autor;
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool DeleteMusica(Musica musica)
    {
        var mus = DbContext.Musica.FirstOrDefault(u => u.id == musica.id);
        if (mus != null)
        {
            DbContext.Remove(mus);
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }


}