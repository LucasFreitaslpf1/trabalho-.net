//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using Dados;
using Microsoft.EntityFrameworkCore;


namespace Services;

public class SampleService
{
    
    protected readonly DatabaseContext DbContext;

    public SampleService(DatabaseContext db)
    {
        DbContext = db;
    }


    public List<Sample> getAllSample()
    {
        return DbContext.Sample.ToList();
    }

    public Task InsertSample(Sample inst)
    {
        DbContext.Sample.Add(inst);
        return DbContext.SaveChangesAsync();
    }

    public Task EditSample(int instId)
    {
        Sample samp = new Sample();
        return DbContext.Sample.FirstOrDefaultAsync(i => i.id == instId);
    }


    public bool UpdateSample(Sample samp)
    {
        var inst = DbContext.Sample.FirstOrDefault(i => i.id == samp.id);
        if (inst != null)
        {
            inst.id = samp.id;
            inst.dataPostagem = samp.dataPostagem;
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool DeleteSample(Sample samp)
    {
        var s = DbContext.Sample.FirstOrDefault(u => u.id == samp.id);
        if (s != null)
        {
            DbContext.Remove(s);
            DbContext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }




}