using Dados;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class InstrumentoService
{
    protected readonly DatabaseContext DbContext;

    public InstrumentoService(DatabaseContext db)
    {
        DbContext = db;
    }

    public List<Instrumento> getAllInstrumento()
    {
        return DbContext.Instrumento.ToList();
    }

    public Task InsertInstrumento(Instrumento inst)
    {
        DbContext.Instrumento.Add(inst);
        return DbContext.SaveChangesAsync();
    }

    public Task EditInstrumento(int instId)
    {
        Instrumento instrumento = new Instrumento();
        return DbContext.Instrumento.FirstOrDefaultAsync(i => i.id == instId);
    }

    public bool UpdateInstrumento(Instrumento instrumento)
    {
        var inst = DbContext.Instrumento.FirstOrDefault(i => i.id == instrumento.id);
        if (inst != null)
        {
            inst.id = instrumento.id;
            inst.nome = instrumento.nome;
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool DeleteInstrumento(Instrumento instrumento)
    {
        var inst = DbContext.Instrumento.FirstOrDefault(u => u.id == instrumento.id);
        if (inst != null)
        {
            DbContext.Remove(inst);
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }
}